using Rosentis.DataContract.Shop;
using Rosentis.DistributedServices;
using Rosentis.DomainModel.Shop;
using Rosentis.ServiceContract.Shop;
using Rosentis.ServiceImplementation.Shop.Mapper;

namespace Rosentis.ServiceImplementation.Shop.Registry
{
    public class InvoiceRegistry : StructureMap.Registry
    {
        public InvoiceRegistry()
        {
            //this.For<IInvoiceService>().Use<InvoiceService>();
            this.For<IEntityMapper<Invoice, InvoiceDto>>().Use<InvoiceMapper>();
            //this.For<IInvoiceRepository>().Use<InvoiceRepository>();
            this.For<IInvoiceApplicationService>().Use<InvoiceApplicationService>();

        }
    }
}