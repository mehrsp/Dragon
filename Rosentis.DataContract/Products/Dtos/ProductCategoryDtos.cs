using Rosentis.DataContract.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rosentis.DataContract.Products.Dtos
{
	public class ProductCategoryDtos: BaseDto
	{
		public List<ProductCategoryDto> ProductCategories { get; set; }

		public ProductCategoryDtos()
		{
			ProductCategories = new List<ProductCategoryDto>();
		}
	}
}
