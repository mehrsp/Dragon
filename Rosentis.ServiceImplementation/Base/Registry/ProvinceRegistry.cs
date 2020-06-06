using Rosentis.ServiceImplementation.Base.Mapper;
using Rosentis.DataContract.Info.Address;
using Rosentis.DistributedServices;
using Rosentis.DomainModel.Base;
using Rosentis.ServiceContract.Info.Address;
using Rosentis.ServiceImplementation.Base;

namespace Rosentis.ServiceImplementation.Base.Registry
{
    public class ProvinceRegistry : StructureMap.Registry
    {
        public ProvinceRegistry()
        {
            this.For<IProvinceService>().Use<ProvinceApplicationService>();
            this.For<IEntityMapper<Province, ProvinceDto>>().Use<ProvinceMapper>();
            //this.For<IProvinceRepository>().Use<ProvinceRepository>();
            //this.For<IProvinceApplicationService>().Use<ProvinceApplicationService>();

        }
    }
}