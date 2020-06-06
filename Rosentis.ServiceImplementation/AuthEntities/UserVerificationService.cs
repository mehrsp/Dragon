using Rosentis.DomainModel.AuthEntities;
using Rosentis.Persistance;
using Rosentis.Persistance.Core.AuthEntities;
using Rosentis.ServiceContract.AuthEntities;
using System;
using System.Linq;

namespace Rosentis.ServiceImplementation.AuthEntities
{
	public class UserVerificationService: IUserVerificationService
	{
		#region Propertieses
		private IUserVerificationRepository _userVerificationRepository;
		private UnitOfWork _unitOfWork = new UnitOfWork();
		#endregion

		#region Ctors
		public UserVerificationService(IUserVerificationRepository userVerificationRepository)
		{
			_userVerificationRepository = userVerificationRepository;
		}
		public int GenerateTwoFactoreCode(long userPhone)
		{
			return _userVerificationRepository.GenerateTwoFactorCode(userPhone);
		}

		public void InvalidateExpiredValidationCodes()
		{
			var date = DateTime.Now.AddDays(-1);
			var items = _unitOfWork.UserVerificationRepository.Get(x => x.IsValidCode && x.CreatedDate < date, null);
			foreach (var item in items)
			{
				item.IsValidCode = false;
				_userVerificationRepository.Save(item);
			}
		}

		public UserVerification GetCode(long phone, int code)
		{
			var item = _unitOfWork.UserVerificationRepository.Get(x => x.Code == code && x.Phone == phone).FirstOrDefault();
			item.IsValidCode = false;
			_unitOfWork.UserVerificationRepository.Update(item);
			return item;
		}

		public UserVerification Find(long phone, int code, bool isValidCode)
		{
			return _unitOfWork.UserVerificationRepository.Get(x => x.IsValidCode && x.Code == code && x.Phone == phone).FirstOrDefault();
		}
		#endregion
	}
}
