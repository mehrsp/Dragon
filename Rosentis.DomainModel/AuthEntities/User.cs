using LabXand.DomainLayer;
using LabXand.DomainLayer.Core;
using Rosentis.DomainModel.Users;
using System;
using System.Collections.Generic;

namespace Rosentis.DomainModel.AuthEntities
{
    public class User 
	{
		public User()
		{
			Roles = new List<Role>();
			Permissions = new List<Permission>();
		}
		public User(long phone, string email, string userName, string displayName, bool isActive, DateTime? lastLoggedIn, string password, List<Role> roles, List<Permission> permissions, string serialNumber, long id)
		{
			UserName = userName;
			Phone = phone;
			Email = email;
			DisplayName = displayName;
			IsActive = isActive;
			LastLoggedIn = lastLoggedIn;
			Password = password;
			if (roles != null) Roles = roles;
			if (permissions != null) Permissions = permissions;
			SerialNumber = serialNumber;
			Id = id;
		}
		public long Id { get; set; }
		public long Phone { get; set; }
        public string Email { get; set; }
		public string UserName {get; set;}
		public string DisplayName {get; set;}
		public bool IsActive {get; set;}
		public DateTime? LastLoggedIn {get; set;}
		public string Password {get; set;}
        public string SerialNumber {get; set;}
        public virtual IList<Permission> Permissions { get; set; }
        public virtual IList<Role> Roles { get; set; }
	}
}
