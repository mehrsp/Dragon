using Rosentis.DomainModel.AuthEntities;

namespace Rosentis.Persistance.Core.AuthEntities
{
    public interface IUsersRepository
    {
        User SaveOrUpdate(User userDto);
        User ChangePassword(User user);
    }
}