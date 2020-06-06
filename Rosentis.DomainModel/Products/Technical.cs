using System.Collections.Generic;

namespace Rosentis.DomainModel.Products
{
	public class Technical
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public virtual Technical Parent { get; set; }
		public int? ParentId { get; set; }
		public virtual ICollection<Technical> Children { get; set; }
	}
}
