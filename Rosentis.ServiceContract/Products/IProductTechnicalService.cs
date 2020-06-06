using Rosentis.DataContract.Base;
using Rosentis.DataContract.Products;
using Rosentis.DataContract.Products.Dtos;

namespace Rosentis.ServiceContract.Products
{
	public interface IProductTechnicalService
	{
		ProductTechnicalDto Save(ProductTechnicalDto dto);
		DtoResponse Remove(ProductTechnicalDto dto);
		ProductTechnicalDtos FindByProductId(long id);
	}
}
