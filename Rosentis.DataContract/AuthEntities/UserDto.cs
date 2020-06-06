using System;
using System.Collections.Generic;
using Rosentis.DataContract.Base;
using Rosentis.DataContract.Users;

namespace Rosentis.DataContract.AuthEntities
{
    public class UserDto: BaseDto
    {
		public string UserName {get; set;}
		public string DisplayName {get; set;}
		public string Email {get; set;}
		public bool IsActive {get; set;}
		public DateTime? LastLoggedIn {get; set;}
		public string Password {get; set;}
		public string SerialNumber {get; set;}
		public long Id {get; set;}
        public long Phone { get; set; }
        public IList<RoleDto> Roles { get; set; }
        public IList<PermissionDto> Permissions { get; set; }
        public UserDto()
        {
            Roles = new List<RoleDto>();
            Permissions = new List<PermissionDto>();
        }

    }
}
