using Rosentis.Persistance.Core.AuthEntities;
using Rosentis.DomainModel.AuthEntities;
using Rosentis.Persistance.Facade;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity.Migrations;

namespace Rosentis.Persistance.Repository.AuthEntities
{
    public class UsersRepository: IUsersRepository
	{
		private RosentisContext context = new RosentisContext();
		public UsersRepository()
        {
        }

        public User SaveOrUpdate(User userDto)
        {
            var model = new User();
            if (userDto.Id == 0)
            {
                model = userDto;
                model.IsActive = true;
                for (int i = 0; i < model.Roles.Count; i++)
                {
                    long id = model.Roles[i].Id;
                    var item = context.Roles.FirstOrDefault(x => x.Id == id);
                    model.Roles[i] = item;
                }
				context.Users.Add(model);
				context.SaveChanges();
            }
            else
            {
                model = context.Set<User>().First(x => x.Id == userDto.Id);
                var count = model.Roles.Count;
                for (int i = 0; i < count; i++)
                {
                    model.Roles.Remove(model.Roles[0]);
                }
                for (int i = 0; i < userDto.Roles.Count; i++)
                {
                    long id = userDto.Roles[i].Id;
                    var item = context.Roles.FirstOrDefault(x => x.Id == id);
                    model.Roles.Add(item);
                }

                model.DisplayName = userDto.DisplayName;
                model.Email = userDto.Email;
                model.Password = userDto.Password;
                model.IsActive = userDto.IsActive;
				context.Set<User>().AddOrUpdate(model, null, null);
				context.SaveChanges();
            }
            return model;
        }

        public User ChangePassword(User user)
        {
            var model = context.Set<User>().FirstOrDefault(x => x.Id == user.Id);
            model.Password = user.Password;
			context.Set<User>().AddOrUpdate(model);
			context.SaveChanges();
            return model;
        }

		private bool disposed = false;
		protected virtual void Dispose(bool disposing)
		{
			if (!this.disposed)
			{
				if (disposing)
				{
					context.Dispose();
				}
			}
			this.disposed = true;
		}


	}
}
