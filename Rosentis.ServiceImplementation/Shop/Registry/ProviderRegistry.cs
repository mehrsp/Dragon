using Rosentis.DataContract.Shop;
using Rosentis.DistributedServices;
using Rosentis.DomainModel.Shop;
using Rosentis.ServiceContract.Shop;
using Rosentis.ServiceImplementation.Shop.Mapper;

namespace Rosentis.ServiceImplementation.Shop.Registry
{
    public class ProviderRegistry : StructureMap.Registry
    {
        public ProviderRegistry()
        {
            //this.For<IProviderService>().Use<ProviderService>();
            this.For<IEntityMapper<Provider, ProviderDto>>().Use<ProviderMapper>();
            //this.For<IProviderRepository>().Use<ProviderRepository>();
            this.For<IProviderApplicationService>().Use<ProviderApplicationService>();

        }
    }
}