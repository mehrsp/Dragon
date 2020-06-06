using Rosentis.DataContract.Base;
using Rosentis.DataContract.Base.Dtos;
using Rosentis.DataContract.Products;
using Rosentis.DataContract.Products.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rosentis.ServiceContract.Products
{
	public interface IProductCategoryService
	{
		ProductCategoryDataDto Save(ProductCategoryDto dto);
		DtoResponse Remove(ProductCategoryDto dto);
		ProductCategoryDataDtos FindAll();
		ProductCategoryDto FindById(int? id);
		DropBoxDtos FillDropBox();
	}
}
