using Rosentis.DataContract.Shop;
using Rosentis.DistributedServices;
using Rosentis.DomainModel.Shop;
using Rosentis.ServiceContract.Shop;
using Rosentis.ServiceImplementation.Shop.Mapper;

namespace Rosentis.ServiceImplementation.Shop.Registry
{
    public class PurchaseRegistry : StructureMap.Registry
    {
        public PurchaseRegistry()
        {
            //this.For<IPurchaseService>().Use<PurchaseService>();
            this.For<IEntityMapper<Purchase, PurchaseDto>>().Use<PurchaseMapper>();
            //this.For<IPurchaseRepository>().Use<PurchaseRepository>();
            this.For<IPurchaseApplicationService>().Use<PurchaseApplicationService>();

        }
    }
}