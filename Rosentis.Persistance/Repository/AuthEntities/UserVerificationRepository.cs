using System;
using System.Data.Entity.Migrations;
using Rosentis.DomainModel.AuthEntities;
using Rosentis.Persistance.Facade;
using Rosentis.Persistance.Core.AuthEntities;

namespace Rosentis.Persistance.Repository.AuthEntities
{
    public class UserVerificationRepository : IUserVerificationRepository
	{
		private RosentisContext context = new RosentisContext();
		public UserVerificationRepository()
        {
            
        }


        public void Save(UserVerification model)
        {
			context.Set<UserVerification>().AddOrUpdate(model);
			context.SaveChanges();
        }

        public int GenerateTwoFactorCode(long userPhone)
        {
            int verificationCode = new Random().Next(10000, 30000);
                UserVerification verification = new UserVerification(userPhone, verificationCode,DateTime.Now,true,Guid.NewGuid());
			    context.UserVerifications.Add(verification);
			    context.SaveChanges();
            return verificationCode;
        }
    }
}
