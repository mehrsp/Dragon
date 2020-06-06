using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rosentis.DataContract.Messaging;
using Rosentis.DomainModel.Messaging;
using Rosentis.ServiceContract.Messaging;
using Rosentis.ServiceImplementation.Messaging.Mapper;

namespace Rosentis.ServiceImplementation.Messaging.Registry
{
    public class MessageRegistry : StructureMap.Registry
    {
        public MessageRegistry()
        {
            //this.For<IMessageService>().Use<MessageService>();
            //this.For<IEntityMapper<Message, MessageDto>>().Use<MessageMapper>();
            //this.For<IMessageRepository>().Use<MessageRepository>();
            this.For<IMessageApplicationService>().Use<MessageApplicationService>();

        }
    }
}