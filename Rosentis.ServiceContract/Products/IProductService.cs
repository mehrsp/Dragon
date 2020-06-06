using Rosentis.Core;
using Rosentis.Core.Filtering;
using Rosentis.DataContract.Products;
using Rosentis.DataContract.Products.Dtos;
using System.Collections.Generic;

namespace Rosentis.ServiceContract.Products
{
	public interface IProductService
	{
		ProductDto Save(ProductDto dto);
		ProductDtos FindAll(SpecificationOfDataList<ProductDto> request);
		FilterResponse<ProductDto> FindAllFiltered(GridRequest request, string ids);
		ProductDto FindById(long id);
		ProductDto FindByChildId(long id);
		ProductDtos FindByProductCategoryId(long id);
		ProductDtos FindPopulars();
		ProductDtos FindMostSells();
		ProductDtos FindNews();
		List<ProductCategoryDto> FindCategoriesWithParent(ProductCategoryDto productCategory);
		decimal FindPagesNumber(int categoryId);
		decimal MaxPrice(SpecificationOfDataList<ProductDto> request);
		decimal MinPrice(SpecificationOfDataList<ProductDto> request);
		double CheckQuantity(long id);
	}
}
