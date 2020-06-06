using Rosentis.DataContract.Base;
using System.Collections.Generic;

namespace Rosentis.DataContract.Products.Dtos
{
	public class ProductDetailDtos : BaseDto
	{
		public List<ProductDetailDto> ProductDetails { get; set; }

		public ProductDetailDtos()
		{
			ProductDetails = new List<ProductDetailDto>();
		}
	}
}
