using Rosentis.DataContract.Base;
using Rosentis.DataContract.Products;
using Rosentis.DataContract.Products.Dtos;

namespace Rosentis.ServiceContract.Products
{
	public interface IProductCategoryTechnicalService
	{
		ProductCategoryTechnicalDto Save(ProductCategoryTechnicalDto dto);
		DtoResponse Remove(ProductCategoryTechnicalDto dto);
		ProductCategoryTechnicalDtos FindByProductCategoryId(int id);
		ProductCategoryTechnicalDto FindById(int id);
	}
}
