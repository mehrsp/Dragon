
using Rosentis.DataContract.AuthEntities;
using Rosentis.DistributedServices;
using Rosentis.DomainModel.AuthEntities;
using Rosentis.Persistance.Core.AuthEntities;
using Rosentis.Persistance.Repository.AuthEntities;
using Rosentis.ServiceContract.AuthEntities;
using Rosentis.ServiceImplementation.AuthEntities.Mapper;

namespace Rosentis.ServiceImplementation.AuthEntities.Registry
{
    public class AuthEntityRegistry : StructureMap.Registry
    {
        public AuthEntityRegistry()
        {
            this.For<IEntityMapper<User, UserDto>>().Use<UserMapper>();
            this.For<IUsersRepository>().Use<UsersRepository>();
            this.For<IUsersApplicationService>().Use<UsersApplicationService>();
			
            this.For<IEntityMapper<UserToken, UserTokenDto>>().Use<UserTokenMapper>();
            this.For<ITokenStoreRepository>().Use<TokenStoreRepository>();
            this.For<ITokenStoreApplicationService>().Use<TokenStoreApplicationService>();
			
            this.For<IUserVerificationRepository>().Use<UserVerificationRepository>();
            this.For<IEntityMapper<Permission, PermissionDto>>().Use<PermissionMapper>();

			this.For<IUserVerificationService>().Use<UserVerificationService>();

		}
    }
}