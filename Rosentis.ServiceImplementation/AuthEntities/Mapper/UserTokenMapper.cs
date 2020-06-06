using Rosentis.DataContract.AuthEntities;
using Rosentis.DistributedServices;
using Rosentis.DomainModel.AuthEntities;
using Rosentis.DomainModel.AuthEntities.NullObjects;

namespace Rosentis.ServiceImplementation.AuthEntities.Mapper
{
    public class UserTokenMapper : IEntityMapper<UserToken, UserTokenDto>
    {
        public UserToken CreateFrom(UserTokenDto domainDto)
        {
            if (domainDto == null)
                return new NullUserToken();
            return new UserToken(domainDto.OwnerUserId,domainDto.AccessTokenHash,domainDto.AccessTokenExpirationDateTime,domainDto.RefreshTokenIdHash,domainDto.Subject,domainDto.RefreshTokenExpiresUtc,domainDto.RefreshToken,domainDto.Id);

        }

        public UserTokenDto MapTo(UserToken domain)
        {
            UserTokenDto domainDto = new UserTokenDto();
            if (domain != null)
            {
				domainDto.OwnerUserId = domain.OwnerUserId;
				domainDto.AccessTokenHash = domain.AccessTokenHash;
				domainDto.AccessTokenExpirationDateTime = domain.AccessTokenExpirationDateTime;
				domainDto.RefreshTokenIdHash = domain.RefreshTokenIdHash;
				domainDto.Subject = domain.Subject;
				domainDto.RefreshTokenExpiresUtc = domain.RefreshTokenExpiresUtc;
				domainDto.RefreshToken = domain.RefreshToken;
				domainDto.Id = domain.Id;

            }

            return domainDto;
        }
    }

}
