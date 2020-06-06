using Rosentis.DataContract.Messaging;
using Rosentis.DomainModel.Messaging;
using Rosentis.DomainModel.Messaging.NullObjects;
using Rosentis.DataContract.AuthEntities;
using Rosentis.DomainModel.AuthEntities;
using Rosentis.DistributedServices;

namespace Rosentis.ServiceImplementation.Messaging.Mapper
{
    public class EmailMapper : IEntityMapper<Email, EmailDto>
    {
		private IEntityMapper<User, UserDto> _userMapper;

        public EmailMapper(IEntityMapper<User, UserDto> userMapper)
        {
		_userMapper = userMapper;

        }
        public Email CreateFrom(EmailDto domainDto)
        {
            if (domainDto == null)
                return new NullEmail();
			return null;
			//domainDto.CreatedById,null,domainDto.CreatedDate,domainDto.Id);

        }

        public EmailDto MapTo(Email domain)
        {
            EmailDto domainDto = new EmailDto();
            if (domain != null)
            {
				domainDto.CreatedById = domain.CreatedById;
				if(domain.CreatedBy!=null)domainDto.CreatedBy = _userMapper.MapTo(domain.CreatedBy);
				domainDto.CreatedDate = domain.CreatedDate;
				domainDto.Id = domain.Id;

            }

            return domainDto;
        }
    }

}