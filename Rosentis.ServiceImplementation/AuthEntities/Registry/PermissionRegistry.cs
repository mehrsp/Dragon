using Rosentis.DataContract.AuthEntities;
using Rosentis.DistributedServices;
using Rosentis.DomainModel.AuthEntities;
using Rosentis.ServiceContract.AuthEntities;
using Rosentis.ServiceImplementation.AuthEntities.Mapper;

namespace Rosentis.ServiceImplementation.AuthEntities.Registry
{
    public class PermissionRegistry : StructureMap.Registry
    {
        public PermissionRegistry()
        {
            this.For<IEntityMapper<Permission, PermissionDto>>().Use<PermissionMapper>();
            //this.For<IPermissionRepository>().Use<PermissionRepository>();
            this.For<IPermissionApplicationService>().Use<PermissionApplicationService>();

        }
    }
}