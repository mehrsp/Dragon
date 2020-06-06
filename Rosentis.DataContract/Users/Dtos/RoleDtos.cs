using Rosentis.DataContract.Base;
using System.Collections.Generic;

namespace Rosentis.DataContract.Users
{
    public class RoleDtos : BaseDto
    {
        public List<RoleDto> Roles { get; set; }

        public RoleDtos()
        {
            Roles = new List<RoleDto>();
        }
    }
}
