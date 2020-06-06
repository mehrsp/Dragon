using System;
using System.Collections.Generic;
using System.Linq;
using Rosentis.DataContract.AuthEntities;
using Rosentis.DomainModel.AuthEntities;
using Rosentis.ServiceContract.AuthEntities;
using Rosentis.DataContract.Users;
using Rosentis.ServiceContract.Messaging;
using Rosentis.Api.Helpers;
using Rosentis.ServiceContract.Users;
using Rosentis.ServiceImplementation.AuthEntities.Mapper;
using Rosentis.Persistance;
using Rosentis.DistributedServices;
using PhoneNumbers;
using Rosentis.Persistance.Core.AuthEntities;
using Rosentis.DataContract.ExeptionModel;
using Rosentis.DomainModel.Users;
using Rosentis.Core;

namespace Rosentis.ServiceImplementation.AuthEntities
{
	public class UsersApplicationService : IUsersApplicationService
	{
		#region Propertieses
		private IUsersRepository _usersRepository;
		private ISmsApplicationService _smsApplicationService;
		private IUserVerificationRepository _userVerificationRepository;
		private IMemberService _memberApplicationService;
		private IEntityMapper<User, UserDto> _mapper;
		private IEntityMapper<Member, MemberDto> _memberMapper;
		private UnitOfWork _unitOfWork = new UnitOfWork();
		#endregion

		#region Ctors
		public UsersApplicationService(UnitOfWork unitOfWork, ISmsApplicationService smsApplicationService,
			IMemberService memberApplicationService, IEntityMapper<User, UserDto> mapper, 
			IUserVerificationRepository userVerificationRepository,
			IUsersRepository usersRepository)  
		{
			_mapper = mapper;
			_smsApplicationService = smsApplicationService;
			_memberApplicationService = memberApplicationService;
			_userVerificationRepository = userVerificationRepository;
			_usersRepository = usersRepository;
		}
		#endregion


		public UserDto Find(long id)
		{
			return _unitOfWork.UserRepository.Get(x => x.Id == id).Select(_mapper.MapTo).FirstOrDefault();
		}

		public void UpdateUserLastActivityDate(long userId)
		{
			var user = FindUser(userId);
			user.LastLoggedIn = DateTime.UtcNow;
		}

		public string GetSerialNumber(int parse)
		{
			var user = FindUser(parse);
			return user.SerialNumber;
		}

		public UserDto FindUser(string contextUserName, string contextPassword)
		{
			return _unitOfWork.UserRepository.Get(x => x.UserName == contextUserName).Select(_mapper.MapTo).FirstOrDefault();
		}

		public UserDto FindByPhone(long phone)
		{
			return _unitOfWork.UserRepository.Get(x=>x.Phone == phone).Select(_mapper.MapTo).FirstOrDefault();
		}

		private bool _isPhoneNumberValid(string strNumber)
		{
			string iranNumberStr = strNumber;
			PhoneNumber number;
			try
			{
				number = PhoneNumberUtil.GetInstance().Parse(iranNumberStr, "IR");
				if (number.HasNationalNumber)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			catch (NumberParseException e)
			{
				return false;
			}
		}
		public void GenerateVerificationCode(long phoneNumber)
		{
			var user = _unitOfWork.UserRepository.Get(x => x.Phone == phoneNumber).FirstOrDefault();
			if (user == null)
			{
				var userDto = new UserDto()
				{
					Id = 0,
					UserName = phoneNumber.ToString(),
					DisplayName = "کاربر",
					IsActive = true,
					LastLoggedIn = null,
					Phone = phoneNumber,
					SerialNumber = Guid.NewGuid().ToString("N")
				};
				_unitOfWork.UserRepository.Insert(_mapper.CreateFrom(userDto));
			}
			var code = _userVerificationRepository.GenerateTwoFactorCode(phoneNumber);
			_smsApplicationService.Send(phoneNumber, "سلام. کد اعتبار سنجی رزِنتیس: " + code);
		}

		public ChangePasswordRequestDto ChangePassword(ChangePasswordRequestDto userDto)
		{
			var user = Find(userDto.UserId);

			if (user == null)
			{
				userDto.AddException(new ExceptionDto()
				{
					Title = "خطای اعتبار سنجی",
					Message = "دسترسی غیر مجاز",
					Id = 1,
				});
			}
			else
			{
				if (user.Password != SecurityHelper.GetSha256Hash(userDto.CurrentPassword))
				{
					userDto.AddException(new ExceptionDto()
					{
						Title = "خطای اعتبار سنجی",
						Message = "کلمه عبور کنونی صحیح وارد نشده است",
						Id = 2,
					});
				}
				else
				{
					user.Password = SecurityHelper.GetSha256Hash(userDto.NewPassword);
					_usersRepository.ChangePassword(_mapper.CreateFrom(user));
				}
			}
			return userDto;
		}

		public MemberDto CreateMember(long dataPhone)
		{
			UserDto user = new UserDto()
			{
				Phone = dataPhone
			};
			user = Save(user);
			var member = new MemberDto
			{
				Id = user.Id,
				User = user,
				CreatedDate = DateTime.Now,
			};
			//var memberDto = _memberApplicationService.CreateMember(_memberMapper.CreateFrom(member));
			return new MemberDto();
		}

		public UserDto FindByPhoneCode(long phone, int code)
		{
			UserDto dto = new UserDto(); ;
			var date = DateTime.Now.AddDays(-1);
			var items = _unitOfWork.UserVerificationRepository.Get(x => x.IsValidCode && x.CreatedDate < date, null).ToList();
			foreach (var rec in items)
			{
				rec.IsValidCode = false;
				_userVerificationRepository.Save(rec);
			}
			UserVerification item = GetCode(phone, code);
			if (item != null)
			{
				item.IsValidCode = false;
				_userVerificationRepository.Save(item);
				return FindByPhone(phone);
			}
			else
			{
				dto.AddException(new ExceptionDto()
				{
					Id = 3,
					Title = "خطای اعتبار سنجی",
					Message = "کاربری با مشخصات ذیل یافت نشد"
				});
				return dto;
			}
		}

		public UserDto FindByEmail(string email)
		{
			return _unitOfWork.UserRepository.Get(x => x.Email == email).Select(_mapper.MapTo).FirstOrDefault();

		}

		public IList<UserDto> FindAll()
		{
			return _unitOfWork.UserRepository.Get().Select(_mapper.MapTo).ToList();
		}

		public UserDto Save(UserDto dto)
		{
			if (dto.Id == 0)
			{
				if (!string.IsNullOrEmpty(dto.UserName))
				{
					var filter = new EqualCriteria()
					{
						FirstOprand = "UserName",
						ObjectType = typeof(string),
						SecondOperand = dto.UserName
					};
					var exist = _unitOfWork.UserRepository.Get(x => x.UserName == dto.UserName).FirstOrDefault();
					if (exist != null)
					{
						dto.Exceptions.Add(new ExceptionDto()
						{
							Message = "این نام کاربری قبلا انتخاب شده است",
							Title = "نام کاربری موجود است"
						});
						return dto;
					}
				}
				if (dto.Phone != 0)
				{
					var filter = new EqualCriteria()
					{
						FirstOprand = "Phone",
						ObjectType = typeof(long),
						SecondOperand = dto.Phone
					};
					var exist = _unitOfWork.UserRepository.Get(x => x.Phone == dto.Phone).FirstOrDefault();
					if (exist != null)
					{
						dto.Exceptions.Add(new ExceptionDto()
						{
							Message = "شماره تماس تکراری است",
							Title = "این شماره تماس قبلا ثبت شده است"
						});
						return dto;
					}
				}
				var userDto = new UserDto()
				{
					Id = 0,
					UserName = dto.UserName,
					DisplayName = dto.DisplayName,
					IsActive = true,
					Phone = dto.Phone,
					LastLoggedIn = null,
					Email = dto.Email,
					SerialNumber = Guid.NewGuid().ToString("N"),
				};
				if (dto.Password != null)
				{
					userDto.Password = SecurityHelper.GetSha256Hash(dto.Password);
				}
				//var createdBy = Find(1);
				//if (createdBy.Roles.FirstOrDefault(x => x.Name == "Admin") != null)
				//{
				//	userDto.Roles = dto.Roles;
				//}
				var model = _usersRepository.SaveOrUpdate(_mapper.CreateFrom(userDto));
				var result = _unitOfWork.UserRepository.Get(x =>x.Id == model.Id).Select(_mapper.MapTo).FirstOrDefault();
				return result;
			}
			else
			{
				var result = _unitOfWork.UserRepository.Get(x => x.Id == dto.Id).Select(_mapper.MapTo).FirstOrDefault();
				if (result != null)
				{
					result.IsActive = dto.IsActive;
					result.DisplayName = dto.DisplayName;
					result.Phone = dto.Phone;
					result.Email = dto.Email;
					var createdBy = Find(1);
					if (createdBy.Roles.FirstOrDefault(x => x.Name == "Admin") != null)
					{
						result.Roles = dto.Roles;
					}
					_usersRepository.SaveOrUpdate(_mapper.CreateFrom(result));
					result = _unitOfWork.UserRepository.Get(x => x.Id == dto.Id).Select(_mapper.MapTo).FirstOrDefault();
				}
				return result;
			}
		}

		public bool Remove(UserDto dto)
		{
			_unitOfWork.UserRepository.Delete(dto.Id);
			return true;
		}

		#region Functions
		public User FindUser(long userId)
		{
			return _unitOfWork.UserRepository.Get(x => x.Id == userId).FirstOrDefault();
		}
		public UserVerification GetCode(long phone, int code)
		{
			var item = _unitOfWork.UserVerificationRepository.Get(x => x.Code == code && x.Phone == phone).FirstOrDefault();
			item.IsValidCode = false;
			_unitOfWork.UserVerificationRepository.Update(item);
			return item;
		}

		#endregion
	}
}
