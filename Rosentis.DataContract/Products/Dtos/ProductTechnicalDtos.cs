using Rosentis.DataContract.Base;
using System.Collections.Generic;

namespace Rosentis.DataContract.Products.Dtos
{
	public class ProductTechnicalDtos: BaseDto
	{
		public List<ProductTechnicalDto> ProductTechnicals { get; set; }

		public ProductTechnicalDtos()
		{
			ProductTechnicals = new List<ProductTechnicalDto>();
		}
	}
}
