using Rosentis.DataContract.Base;
using Rosentis.DataContract.Base.Dtos;
using Rosentis.DataContract.Products;
using Rosentis.DataContract.Products.Dtos;
using Rosentis.ServiceContract.Products;
using System.Web.Http;

namespace Rosentis.Api.Controllers.Products
{
	[RoutePrefix("api/ProductCategoryTechnicals")]
	public class ProductCategoryTechnicalsController : ApiController
	{
		private IProductCategoryTechnicalService _productCategoryTechnicalService;
		public ProductCategoryTechnicalsController(IProductCategoryTechnicalService ProductCategoryTechnicalService)
		{
			_productCategoryTechnicalService = ProductCategoryTechnicalService;
		}
		
		[HttpPost]
		[Route("Save")]
		public ProductCategoryTechnicalDto Save(ProductCategoryTechnicalDto dto)
		{
			return _productCategoryTechnicalService.Save(dto);
		}

		[HttpPost]
		[Route("Remove")]
		public DtoResponse Remove(ProductCategoryTechnicalDto dto)
		{
			return _productCategoryTechnicalService.Remove(dto);
		}

		[HttpPost]
		[Route("FindById")]
		public ProductCategoryTechnicalDto FindById(int id)
		{
			return _productCategoryTechnicalService.FindById(id);
		}

		[HttpPost]
		[Route("FindByProductCategoryId")]
		public ProductCategoryTechnicalDtos FindByProductCategoryId(int id)
		{
			return _productCategoryTechnicalService.FindByProductCategoryId(id);
		}

	}
}