using Rosentis.DataContract.Base;
using System.Collections.Generic;
namespace Rosentis.DataContract.Products.Dtos
{
    public class ProductImageDtos : BaseDto
    {
		public List<ProductImageDto> ProductImages { get; set; }

		public ProductImageDtos()
		{
			ProductImages = new List<ProductImageDto>();
		}
	}
}
