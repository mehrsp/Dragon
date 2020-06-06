using Rosentis.ServiceImplementation.Users.Mapper;
using Rosentis.DataContract.Users;
using Rosentis.DistributedServices;
using Rosentis.DomainModel.Users;
using Rosentis.ServiceContract.Users;
using Rosentis.ServiceImplementation.Users;

namespace Rosentis.ServiceImplementation.Users.Registry
{
    public class UsersRegistry : StructureMap.Registry
    {
        public UsersRegistry()
        {
            //this.For<IMemberService>().Use<MemberService>();
            this.For<IEntityMapper<Member, MemberDto>>().Use<MemberMapper>();
            //this.For<IMemberRepository>().Use<MemberRepository>();
            this.For<IMemberService>().Use<MemberApplicationService>();

            //this.For<ISessionService>().Use<SessionService>();
            this.For<IEntityMapper<Session, SessionDto>>().Use<SessionMapper>();
            //this.For<ISessionRepository>().Use<SessionRepository>();
            this.For<ISessionApplicationService>().Use<SessionApplicationService>();

            //this.For<IRoleService>().Use<RoleService>();
            this.For<IEntityMapper<Role, RoleDto>>().Use<RoleMapper>();
            //this.For<IRoleRepository>().Use<RoleRepository>();
            this.For<IRoleApplicationService>().Use<RoleApplicationService>();

        }
    }
}