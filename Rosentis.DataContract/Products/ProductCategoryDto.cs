using Rosentis.DataContract.Base;
using System;
using System.Collections.Generic;

namespace Rosentis.DataContract.Products
{
	public class ProductCategoryDto : BaseDto
	{
		public int Id { get; set; }
		public int? ParentId { get; set; }
		public string Name { get; set; }
		public int Priority { get; set; }
		public long CreatedById { get; set; }
		//public ICollection<ProductDto> Products { get; set; }
		public  ICollection<ProductCategoryDto> Children { get; set; }
		ProductCategoryDto()
		{
			//Products = new List<ProductDto>();
			//Children = new List<ProductCategoryDto>();
		}
	}
}
