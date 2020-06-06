﻿namespace Rosentis.DomainModel.AuthEntities
{
    public class UserPermission
    {
        public long PermissionId { get; set; }
        public long UserId { get; set; }
        public virtual Permission Permission { get; set; }
        public virtual User User { get; set; }
    }
}
