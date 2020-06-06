using Rosentis.DataContract.Base;
using Rosentis.DataContract.Products;
using Rosentis.DataContract.Products.Dtos;

namespace Rosentis.ServiceContract.Products
{
    public interface IProductImageService
	{
		ProductImageDto Save(ProductImageDto dto);
		DtoResponse Remove(ProductImageDto dto);
		ProductImageDtos FindByProductId(long id);
	}
}
