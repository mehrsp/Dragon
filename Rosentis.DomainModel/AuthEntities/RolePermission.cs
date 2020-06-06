using Rosentis.DomainModel.Users;

namespace Rosentis.DomainModel.AuthEntities
{
    public class RolePermission
    {
        public long PermissionId { get; set; }
        public virtual Permission Permission { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}
