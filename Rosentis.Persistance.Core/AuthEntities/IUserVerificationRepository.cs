using Rosentis.DomainModel.AuthEntities;

namespace Rosentis.Persistance.Core.AuthEntities
{
    public interface IUserVerificationRepository
	{
        int GenerateTwoFactorCode(long userPhone);
        void Save(UserVerification item);
    }
}