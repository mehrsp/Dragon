using System.Collections.Generic;
using Rosentis.DataContract.Users;

namespace Rosentis.ServiceContract.Users
{
    public interface IRoleApplicationService
    {
        RoleDto Save(RoleDto dto);
        bool Remove(RoleDto dto);
        RoleDtos FindAll();
        RoleDto Find(int id);
    }
}
