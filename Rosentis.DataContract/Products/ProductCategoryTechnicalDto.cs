using Rosentis.DataContract.Base;
using Rosentis.DataContract.Brands;

namespace Rosentis.DataContract.Products
{
	public class ProductCategoryTechnicalDto: BaseDto
	{
		public long Id { get; set; }
		public int ProductCategoryId { get; set; }
		public int? TechnicalId { get; set; }
		public TechnicalChildDto Technical { get; set; }
		public int? BrandId { get; set; }
		public BrandDto Brand { get; set; }
	}
}
