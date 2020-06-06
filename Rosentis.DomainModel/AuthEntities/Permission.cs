using LabXand.DomainLayer;
using LabXand.DomainLayer.Core;
using System;
using System.Collections.Generic;

namespace Rosentis.DomainModel.AuthEntities
{
	public class Permission
	{
		public long Id { get; set; }
        public string Name { get; set; }
        public virtual Permission Parent { get; set; }
        public virtual ICollection<Permission> Children { get; set; }
		public Permission()
		{
			Children = new List<Permission>();
		}
	}
}
