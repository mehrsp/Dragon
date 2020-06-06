using Rosentis.DataContract.Base;
using System.Collections.Generic;

namespace Rosentis.DataContract.Products.Dtos
{
	public class ProductCatalogDtos: BaseDto
	{
		public List<ProductCatalogDto> ProductCatalogs { get; set; }

		public ProductCatalogDtos()
		{
			ProductCatalogs = new List<ProductCatalogDto>();
		}
	}
}
