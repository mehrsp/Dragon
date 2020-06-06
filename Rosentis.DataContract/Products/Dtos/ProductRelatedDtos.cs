using Rosentis.DataContract.Base;
using System.Collections.Generic;

namespace Rosentis.DataContract.Products.Dtos
{
	public class ProductRelatedDtos: BaseDto
	{
		public List<ProductRelatedDto> ProductRelateds { get; set; }

		public ProductRelatedDtos()
		{
			ProductRelateds = new List<ProductRelatedDto>();
		}
	}
}
