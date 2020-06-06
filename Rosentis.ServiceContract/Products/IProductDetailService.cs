using Rosentis.DataContract.Base;
using Rosentis.DataContract.Products;
using Rosentis.DataContract.Products.Dtos;

namespace Rosentis.ServiceContract.Products
{
	public interface IProductDetailService
	{
		ProductDetailDto Save(ProductDetailDto dto);
		DtoResponse Remove(ProductDetailDto dto);
		ProductDetailDtos FindAll();
		ProductDetailDtos FindByProductId(long id);
	}
}
