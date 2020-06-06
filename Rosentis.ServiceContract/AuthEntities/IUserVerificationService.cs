using Rosentis.DomainModel.AuthEntities;

namespace Rosentis.ServiceContract.AuthEntities
{
	public interface IUserVerificationService
	{
		int GenerateTwoFactoreCode(long userPhone);
		void InvalidateExpiredValidationCodes();
		UserVerification GetCode(long phone, int code);
		UserVerification Find(long phone, int code, bool isValidCode);
	}
}
