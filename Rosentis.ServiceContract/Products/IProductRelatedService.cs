using Rosentis.DataContract.Base;
using Rosentis.DataContract.Products;
using Rosentis.DataContract.Products.Dtos;

namespace Rosentis.ServiceContract.Products
{
	public interface IProductRelatedService
	{
		ProductRelatedDto Save(ProductRelatedDto dto);
		DtoResponse Remove(ProductRelatedDto dto);
		ProductRelatedDtos FindByProductId(long id);
	}
}
