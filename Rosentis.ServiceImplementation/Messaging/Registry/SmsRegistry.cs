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
    public class SmsRegistry : StructureMap.Registry
    {
        public SmsRegistry()
        {
            //this.For<ISmsService>().Use<DomainService.Messaging.SmsService>();
            //this.For<IEntityMapper<Sms, SmsDto>>().Use<SmsMapper>();
            //this.For<ISmsRepository>().Use<SmsRepository>();
            this.For<ISmsApplicationService>().Use<SmsApplicationService>();

        }
    }
}