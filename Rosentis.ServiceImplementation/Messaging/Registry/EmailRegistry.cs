using Rosentis.DataContract.Messaging;
using Rosentis.DomainModel.Messaging;
using Rosentis.ServiceContract.Messaging;
using Rosentis.ServiceImplementation.Messaging.Mapper;

namespace Rosentis.ServiceImplementation.Messaging.Registry
{
    public class EmailRegistry : StructureMap.Registry
    {
        public EmailRegistry()
        {
            this.For<IEmailApplicationService>().Use<EmailApplicationService>();

        }
    }
}