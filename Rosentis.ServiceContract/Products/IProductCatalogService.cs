
using Rosentis.DataContract.Base;
using Rosentis.DataContract.Products;
using Rosentis.DataContract.Products.Dtos;

namespace Rosentis.ServiceContract.Products
{
	public interface IProductCatalogService
	{
		ProductCatalogDto Save(ProductCatalogDto dto);
		DtoResponse Remove(ProductCatalogDto dto);
		ProductCatalogDtos FindByProductId(long id);
	}
}
