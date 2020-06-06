using AutoMapper;
using Rosentis.DataContract.Base;
using Rosentis.DataContract.ExeptionModel;
using Rosentis.Persistance;
using Rosentis.ServiceContract.Suppliers;
using System;
using System.Collections.Generic;
using Rosentis.DomainModel.Users;
using Rosentis.DataContract.Users.Dtos;
using Rosentis.DataContract.Users;
using Rosentis.ServiceImplementation.Users;
using Rosentis.DataContract.Info.Address;
using Rosentis.DataContract.Base.Dtos;
using Rosentis.DomainModel.AuthEntities;
using Rosentis.Persistance.Facade;
using Rosentis.ServiceContract.AuthEntities;
using Rosentis.ServiceContract.Users;

namespace Rosentis.ServiceImplementation.Products
{
	public class SupplierApplicationService : ISupplierService
	{
		#region Properties
		private UnitOfWork _unitOfWork = new UnitOfWork();
		private IUsersApplicationService _userService;
		#endregion Properties

		#region Ctors
		public SupplierApplicationService(RosentisContext context, IUsersApplicationService UserService ) 
		{
			_userService = UserService;
		}
		#endregion Ctors

		#region Utilities
		//private SupplierDtos FindByPredicate(Expression<Func<Supplier, bool>> predicate = null)
		//{
		//	var list = new List<Supplier>();

		//	_unitOfWork.SupplierRepository.SetIncludes(x => x.CreatedBy);

		//	if (null == predicate)
		//		list = _unitOfWork.SupplierRepository.Get().ToList;
		//	else
		//		list = _unitOfWork.SupplierRepository.Get(predicate).ToList();

		//	//var docs = Mapper.Map<List<DocumentDto>>(list); !!!!!
		//	var productCategories = new List<SupplierDto>();
		//	foreach (var pcategory in list)
		//	{
		//		productCategories.Add(Mapper.Map<SupplierDto>(pcategory));
		//	}
		//	return new SupplierDtos()
		//	{
		//		ProductCategories = productCategories
		//	};
		//}
		#endregion Utilities

		#region Methods
		public SupplierDtos FindAll()
		{
			return new SupplierDtos
			{
			Suppliers = Mapper.Map<List<SupplierDto>>(_unitOfWork.SupplierRepository.Get())
			};
		}
		public DropBoxDtos FillDropBox()
		{
			return new DropBoxDtos
			{
				Items = Mapper.Map<List<DropBoxDto>>(_unitOfWork.SupplierRepository.Get())
			};
		}
		public SupplierDto FindById(long id)
		{
			_unitOfWork.SupplierRepository.SetIncludes(x => x.Province, x=>x.City);
			var supplier = Mapper.Map<SupplierDto>(_unitOfWork.SupplierRepository.GetFirst(x => x.Id == id));
			//supplier.User = new UserDto { UserName = (_unitOfWork.UserRepository.GetFirst(x => x.UserId == id)).UserName };

			if(supplier.Province != null)
				supplier.Province = new ProvinceDto() { Id = supplier.Province.Id, Name = supplier.Province.Name  };
			return supplier;
		}
		public SupplierDto Save(SupplierDto dto)
		{
			var Supplier = new Supplier();
			
			Supplier = _unitOfWork.SupplierRepository.GetByID(dto.Id);

			//Supplier.ModifiedDate = DateTime.Now;
			Supplier.Name = dto.Name;
			Supplier.EconomicCode = dto.EconomicCode;
			Supplier.Fax = dto.Fax;
			Supplier.Latitude = dto.Latitude;
			Supplier.Longitude = dto.Longitude;
			Supplier.Logo = dto.Logo;
			Supplier.NationalID = dto.NationalID;
			Supplier.PaymentMethod = dto.PaymentMethod;
			Supplier.Website = dto.Website;
			Supplier.PostalCode = dto.PostalCode;
			Supplier.CompanyType = dto.CompanyType;

			_unitOfWork.SupplierRepository.Update(Supplier);
			_unitOfWork.Save();


			var member = _unitOfWork.MemberRepository.GetFirst(x => x.Id == dto.Id);
			member.Phone = dto.Phone;
			member.ProvinceId = dto.ProvinceId;
			member.CityId = dto.CityId;
			member.MemberType = Common.MemberType.Company;
			member.Description = dto.Description;
			member.Email = dto.Email;

			_unitOfWork.MemberRepository.Update(member);
			_unitOfWork.Save();

			dto.Id = member.Id;
			
			return dto; 
		}
		public DtoResponse Remove(SupplierDto dto)
		{
			try
			{
				var Supplier = _unitOfWork.SupplierRepository.GetFirst(x => x.Id == dto.Id);
				if (Supplier != null && Supplier.Id > 0)
				{
				    //checked if haved product
				   var product = _unitOfWork.ProductRepository.GetFirst(x => x.SupplierId == dto.Id);
				   if (product != null)
				   {
					  var dtoResponse = new DtoResponse();
					  dtoResponse.AddException(Mapper.Map<ExceptionDto>(_unitOfWork.Exception.GetFirst(x => x.Id == 5)));
					
				   return dtoResponse;
			       }
				   
					_unitOfWork.SupplierRepository.Delete(dto.Id);
					_unitOfWork.Save();
				}

				return new DtoResponse();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public User CreateSupplier(User userInfo)
		{
			//_userService.CreateUser(userInfo);
			return null;
		}

		#endregion Methods
	}
}
