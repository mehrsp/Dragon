using Rosentis.DataContract.Shop;
using Rosentis.DistributedServices;
using Rosentis.DomainModel.Shop;
using Rosentis.ServiceContract.Shop;
using Rosentis.ServiceImplementation.Shop.Mapper;

namespace Rosentis.ServiceImplementation.Shop.Registry
{
    public class PurchaseTypeRegistry : StructureMap.Registry
    {
        public PurchaseTypeRegistry()
        {
            //this.For<IPurchaseTypeService>().Use<PurchaseTypeService>();
            this.For<IEntityMapper<PurchaseType, PurchaseTypeDto>>().Use<PurchaseTypeMapper>();
            //this.For<IPurchaseTypeRepository>().Use<PurchaseTypeRepository>();
            this.For<IPurchaseTypeApplicationService>().Use<PurchaseTypeApplicationService>();

        }
    }
}