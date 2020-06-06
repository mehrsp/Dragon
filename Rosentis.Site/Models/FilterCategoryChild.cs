using Rosentis.DataContract.Products;
using System.Collections.Generic;

namespace Rosentis.Site.Models
{
	public class FilterCategoryChild
	{
		public ProductCategoryDto OriginalCategory { get; set; }
		public List<ProductCategoryDto> Categories { get; set; }
		public List<int> list { get; set; }
		public FilterCategoryChild()
		{
			Categories = new List<ProductCategoryDto>();
		}
	}
}