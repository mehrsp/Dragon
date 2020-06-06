using Rosentis.DomainModel.Base;
using Rosentis.DomainModel.Brands;

namespace Rosentis.DomainModel.Products
{
	public class ProductCategoryTechnical
	{
		public long Id { get; set; }
		public virtual ProductCategory ProductCategory { get; set; }
		public int ProductCategoryId { get; set; }
		//for filter with product technicals
		public virtual Technical Technical { get; set; }
		public int? TechnicalId { get; set; } = 0;
		//for filter with brands 
		public virtual Brand Brand { get; set; }
		public int? BrandId { get; set; } 
	}
}
