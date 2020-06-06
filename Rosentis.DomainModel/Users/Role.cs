using System;
using System.Collections.Generic;
using Rosentis.DomainModel.AuthEntities;

namespace Rosentis.DomainModel.Users
{
    public class Role 
    {
		public int Id { get; set; }
		public string Name {get; set;}
        //Navigation Properties
        public virtual ICollection<Permission> Permissions { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
