using Rosentis.DataContract.AuthEntities;
using Rosentis.DataContract.Base;
using System.Collections.Generic;

namespace Rosentis.DataContract.Users
{
    public class RoleDto: BaseDto
    {
        public RoleDto()
        {
            Permissions = new List<PermissionDto>();
        }
		public string Name {get; set;}
		public int Id {get; set;}
        public List<PermissionDto> Permissions { get; set; }
    }
}
