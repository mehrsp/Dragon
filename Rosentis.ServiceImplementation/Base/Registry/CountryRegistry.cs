
using Rosentis.ServiceImplementation.Base.Mapper;
using Rosentis.DataContract.Info.Address;
using Rosentis.DistributedServices;
using Rosentis.DomainModel.Base;
using Rosentis.ServiceContract.Info.Address;
using Rosentis.ServiceImplementation.Base;

namespace Rosentis.ServiceImplementation.Base.Registry
{
    public class CountryRegistry : StructureMap.Registry
    {
        public CountryRegistry()
        {
            //this.For<ICountryService>().Use<CountryService>();
            //this.For<IEntityMapper<Country, CountryDto>>().Use<CountryMapper>();
            //this.For<ICountryRepository>().Use<CountryRepository>();
            this.For<ICountryService>().Use<CountryApplicationService>();

        }
    }
}