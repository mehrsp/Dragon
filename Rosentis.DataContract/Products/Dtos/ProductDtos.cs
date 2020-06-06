using Rosentis.DataContract.Base;
using System.Collections.Generic;

namespace Rosentis.DataContract.Products.Dtos
{
	public class ProductDtos: BaseDto
	{
		public List<ProductDto> Products { get; set; }

		public ProductDtos()
		{
			Products = new List<ProductDto>();
		}
	}
}
