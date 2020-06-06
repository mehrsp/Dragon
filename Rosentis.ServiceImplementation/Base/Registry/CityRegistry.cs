
using Rosentis.ServiceImplementation.Base.Mapper;
using Rosentis.DataContract.Info.Address;
using Rosentis.DistributedServices;
using Rosentis.DomainModel.Base;
using Rosentis.ServiceContract.Info.Address;
using Rosentis.ServiceImplementation.Base;

namespace Rosentis.ServiceImplementation.Base.Registry
{
    public class CityRegistry : StructureMap.Registry
    {
        public CityRegistry()
        {
            //this.For<ICityService>().Use<CityService>();
            this.For<IEntityMapper<City, CityDto>>().Use<CityMapper>();
            //this.For<ICityRepository>().Use<CityRepository>();
            this.For<ICityService>().Use<CityApplicationService>();

        }
    }
}