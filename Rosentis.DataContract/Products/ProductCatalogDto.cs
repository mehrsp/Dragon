
using Rosentis.DataContract.Base;


namespace Rosentis.DataContract.Products
{
	public class ProductCatalogDto : BaseDto
	{
		public long Id { get; set; }
		public string Title { get; set; }
		public virtual ProductDto Product { get; set; }
		public long ProductId { get; set; }
		public long CreatedById { get; set; }
	}
}
