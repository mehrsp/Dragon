using Rosentis.DataContract.Base;
namespace Rosentis.DataContract.Products
{
	public class ProductDetailDto : BaseDto
	{
		public long Id { get; set; }
		public string Name { get; set; }
		public decimal? Price { get; set; }
		public bool? IsQuantity { get; set; }
		public double? Quantity { get; set; }
		public double? Ranking { get; set; }
		public long? SoldCount { get; set; }
		public long? ProductId { get; set; }
		public long CreatedById { get; set; }
		public long ModifiedById { get; set; }
	}
}
