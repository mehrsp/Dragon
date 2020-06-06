using Rosentis.ServiceImplementation.Users.Mapper;
using Rosentis.DataContract.Users;
using Rosentis.DistributedServices;
using Rosentis.DomainModel.Users;
using Rosentis.ServiceContract.Users;
using Rosentis.ServiceImplementation.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rosentis.ServiceImplementation.Users.Registry
{
    public class MemberRegistry : StructureMap.Registry
    {
        public MemberRegistry()
        {
            //this.For<IMemberService>().Use<MemberService>();
            this.For<IEntityMapper<Member, MemberDto>>().Use<MemberMapper>();
            //this.For<IMemberRepository>().Use<MemberRepository>();
            this.For<IMemberService>().Use<MemberApplicationService>();

        }
    }
}