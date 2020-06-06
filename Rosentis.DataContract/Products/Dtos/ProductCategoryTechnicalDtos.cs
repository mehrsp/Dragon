using Rosentis.DataContract.Base;
using System.Collections.Generic;

namespace Rosentis.DataContract.Products.Dtos
{
	public class ProductCategoryTechnicalDtos: BaseDto
	{
		public List<ProductCategoryTechnicalDto> ProductCategoryTechnicals { get; set; }

		public ProductCategoryTechnicalDtos()
		{
			ProductCategoryTechnicals = new List<ProductCategoryTechnicalDto>();
		}
	}
}
