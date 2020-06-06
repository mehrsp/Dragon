using Rosentis.Persistance.Core.AuthEntities;
using Rosentis.DomainModel.AuthEntities;
using Rosentis.Persistance.Facade;
using System.Data.Entity.Migrations;

namespace Rosentis.Persistance.Repository.AuthEntities
{
    public class TokenStoreRepository: ITokenStoreRepository
	{
		private RosentisContext context = new RosentisContext();
		public TokenStoreRepository() 
        {
        }

        public void Save(UserToken userToken)
        {
            context.UserTokens.Add(userToken);
            context.SaveChanges();
        }

        public void Update(UserToken token)
        {
            context.Set<UserToken>().AddOrUpdate(token);
            context.SaveChanges();
        }
    }
}
