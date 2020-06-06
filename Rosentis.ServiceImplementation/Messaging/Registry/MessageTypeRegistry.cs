using Rosentis.DataContract.Messaging;
using Rosentis.DomainModel.Messaging;
using Rosentis.ServiceContract.Messaging;
using Rosentis.ServiceImplementation.Messaging.Mapper;

namespace Rosentis.ServiceImplementation.Messaging.Registry
{
    public class MessageTypeRegistry : StructureMap.Registry
    {
        public MessageTypeRegistry()
        {
            //this.For<IMessageTypeService>().Use<MessageTypeService>();
            //this.For<IEntityMapper<MessageType, MessageTypeDto>>().Use<MessageTypeMapper>();
            //this.For<IMessageTypeRepository>().Use<MessageTypeRepository>();
            this.For<IMessageTypeApplicationService>().Use<MessageTypeApplicationService>();

        }
    }
}