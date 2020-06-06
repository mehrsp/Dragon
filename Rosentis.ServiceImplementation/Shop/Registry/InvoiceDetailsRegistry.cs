using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rosentis.DataContract.Shop;
using Rosentis.DomainModel.Shop;
using Rosentis.ServiceContract.Shop;
using Rosentis.ServiceImplementation.Shop.Mapper;
using Rosentis.DistributedServices;

namespace Rosentis.ServiceImplementation.Shop.Registry
{
    public class InvoiceDetailsRegistry : StructureMap.Registry
    {
        public InvoiceDetailsRegistry()
        {
            //this.For<IInvoiceDetailsService>().Use<InvoiceDetailsService>();
            this.For<IEntityMapper<InvoiceDetails, InvoiceDetailsDto>>().Use<InvoiceDetailsMapper>();
            //this.For<IInvoiceDetailsRepository>().Use<InvoiceDetailsRepository>();
            this.For<IInvoiceDetailsApplicationService>().Use<InvoiceDetailsApplicationService>();

        }
    }
}