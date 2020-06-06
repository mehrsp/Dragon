
using Rosentis.DataContract.Users;
using Rosentis.DistributedServices;
using Rosentis.DomainModel.Users;

namespace Rosentis.ServiceImplementation.Users.Mapper
{
    public class SessionMapper : IEntityMapper<Session, SessionDto>
    {
        private IEntityMapper<Member, MemberDto> _memberMapper;

        public SessionMapper(IEntityMapper<Member, MemberDto> memberMapper)
        {
            _memberMapper = memberMapper;
        }
        public Session CreateFrom(SessionDto domainDto)
        {
			//if (domainDto == null)
			//    return new NullSession();
			//return new Session(domainDto.Imei, null, domainDto.MemberId, domainDto.Token, domainDto.DeviceType, domainDto.DeviceToken, domainDto.LastLoginDate, domainDto.LastOnlineDate, domainDto.Id);
			return null;
        }

        public SessionDto MapTo(Session domain)
        {
            SessionDto domainDto = new SessionDto();
            if (domain != null)
            {
                domainDto.Imei = domain.Imei;
                if (domain.Member != null)
                {
                    domainDto.Member = _memberMapper.MapTo(domain.Member);
                }
                domainDto.MemberId = domain.MemberId;
                domainDto.Token = domain.Token;
                domainDto.DeviceType = domain.DeviceType;
                domainDto.DeviceToken = domain.DeviceToken;
                domainDto.LastLoginDate = domain.LastLoginDate;
                domainDto.LastOnlineDate = domain.LastOnlineDate;
                domainDto.Id = domain.Id;

            }

            return domainDto;
        }
    }

}
