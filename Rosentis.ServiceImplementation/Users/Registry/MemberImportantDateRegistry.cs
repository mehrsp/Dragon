using Rosentis.ServiceImplementation.Users.Mapper;
using Rosentis.DataContract.Users;
using Rosentis.DistributedServices;
using Rosentis.DomainModel.Users;
using Rosentis.ServiceContract.Users;

namespace Rosentis.ServiceImplementation.Users.Registry
{
    public class MemberImportantDateRegistry : StructureMap.Registry
    {
        public MemberImportantDateRegistry()
        {
            //this.For<IMemberImportantDateService>().Use<MemberImportantDateService>();
            this.For<IEntityMapper<MemberImportantDate, MemberImportantDateDto>>().Use<MemberImportantDateMapper>();
            //this.For<IMemberImportantDateRepository>().Use<MemberImportantDateRepository>();
            this.For<IMemberImportantDateApplicationService>().Use<MemberImportantDateApplicationService>();

        }
    }
}