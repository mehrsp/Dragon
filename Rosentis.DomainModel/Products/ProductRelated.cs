using Rosentis.DomainModel.AuthEntities;
using System;

namespace Rosentis.DomainModel.Products
{
	public class ProductRelated
	{
		public long Id { get; set; }
		public virtual Product Product { get; set; }
		public long ProductId { get; set; }
		public string Link { get; set; }
		public string Description { get; set; }
	}
}
