using Rosentis.DataContract.Messaging;
using Rosentis.DomainModel.Messaging;
using Rosentis.DomainModel.Messaging.NullObjects;
using Rosentis.DataContract.AuthEntities;
using Rosentis.DomainModel.AuthEntities;
using Rosentis.DistributedServices;

namespace Rosentis.ServiceImplementation.Messaging.Mapper
{
    public class SmsMapper : IEntityMapper<Sms, SmsDto>
    {
		private IEntityMapper<User, UserDto> _userMapper;

        public SmsMapper(IEntityMapper<User, UserDto> userMapper)
        {
		_userMapper = userMapper;

        }
        public Sms CreateFrom(SmsDto domainDto)
        {
            if (domainDto == null)
                return new NullSms();
			return new Sms();
				//domainDto.CreatedById,null,domainDto.CreatedDate,domainDto.To,domainDto.Text,domainDto.Id);

        }

        public SmsDto MapTo(Sms domain)
        {
            SmsDto domainDto = new SmsDto();
            if (domain != null)
            {
				domainDto.CreatedById = domain.CreatedById;
				if(domain.CreatedBy!=null)domainDto.CreatedBy = _userMapper.MapTo(domain.CreatedBy);
				domainDto.CreatedDate = domain.CreatedDate;
				domainDto.To = domain.To;
				domainDto.Text = domain.Text;
				domainDto.Id = domain.Id;

            }

            return domainDto;
        }
    }

}