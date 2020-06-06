
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using Rosentis.DomainModel.Users;

namespace Rosentis.DomainModel.Products
{
	public class Comment
	{
		public Comment()
		{
			Children = new HashSet<Comment>();
		}
		public long Id { get; set; }
		public string Description { get; set; }
		public Comment Parent { get; set; }
		public long? ParentId { get; set; }
		public virtual Product Product { get; set; }
		public long ProductId { get; set; }
		public virtual Member Member { get; set; }
		public long MemberId { get; set; }
		public virtual ICollection<Comment> Children { get; set; }
		public DateTime CreatedDate { get; set; }
	}
}
