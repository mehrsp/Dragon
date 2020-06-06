using Rosentis.DataContract.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rosentis.DataContract.Products.Dtos
{
	public class ProductCategoryDataDtos: BaseDto
	{
		public List<ProductCategoryDataDto> data { get; set; }

		public ProductCategoryDataDtos()
		{
			data = new List<ProductCategoryDataDto>();
		}
	}
}
