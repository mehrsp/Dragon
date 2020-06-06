using System.Collections.Generic;

namespace Rosentis.DataContract.Products
{
    public class ProductCategoryDataDto
    {
        public string label { get; set; }
        public string data { get; set; }
        public ProductCategoryDto model { get; set; }
        public List<ProductCategoryDataDto> children { get; set; }
		public ProductCategoryDataDto()
        {
			//children = new List<ProductCategoryDataDto>();
		}
    }
}
