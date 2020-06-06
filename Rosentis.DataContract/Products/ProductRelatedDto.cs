using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rosentis.DataContract.Products
{
	public class ProductRelatedDto
	{
		public long Id { get; set; }
		public virtual ProductDto Product { get; set; }
		public long ProductId { get; set; }
		public string Description { get; set; }
		public string Link { get; set; }
		public long CreatedById { get; set; }
		public long ModifiedById { get; set; }
	}
}
