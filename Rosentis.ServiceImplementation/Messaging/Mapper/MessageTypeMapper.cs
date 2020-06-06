using Rosentis.DataContract.Messaging;
using Rosentis.DomainModel.Messaging;
using Rosentis.DomainModel.Messaging.NullObjects;
using Rosentis.DistributedServices;

namespace Rosentis.ServiceImplementation.Messaging.Mapper
{
    public class MessageTypeMapper : IEntityMapper<MessageType, MessageTypeDto>
    {

        public MessageTypeMapper()
        {

        }
        public MessageType CreateFrom(MessageTypeDto domainDto)
        {
            if (domainDto == null)
                return new NullMessageType();
            return new MessageType(domainDto.Id,domainDto.Name);

        }

        public MessageTypeDto MapTo(MessageType domain)
        {
            MessageTypeDto domainDto = new MessageTypeDto();
            if (domain != null)
            {
				domainDto.Id = domain.Id;
				domainDto.Name = domain.Name;

            }

            return domainDto;
        }
    }

}