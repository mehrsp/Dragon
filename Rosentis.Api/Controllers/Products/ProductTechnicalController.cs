using Rosentis.DataContract.Base;
using Rosentis.DataContract.Base.Dtos;
using Rosentis.DataContract.Products;
using Rosentis.DataContract.Products.Dtos;
using Rosentis.ServiceContract.Products;
using System.Web.Http;
using System.Collections;

namespace Rosentis.Api.Controllers.ProductTechnicals
{
	[RoutePrefix("api/ProductTechnicals")]
	public class ProductTechnicalController: ApiController
	{
		#region Propertises
		private IProductTechnicalService _ProductTechnicalService;
		#endregion

		#region Ctors
		public ProductTechnicalController(IProductTechnicalService ProductTechnicalService)
		{
			_ProductTechnicalService = ProductTechnicalService;
		}
		#endregion

		#region Methods
		[HttpPost]
		[Route("Save")]
		public ProductTechnicalDto Save(ProductTechnicalDto dto)
		{
			return _ProductTechnicalService.Save(dto);
		}

		[HttpPost]
		[Route("Remove")]
		public DtoResponse Remove(ProductTechnicalDto dto)
		{
			return _ProductTechnicalService.Remove(dto);
		}

		[HttpPost]
		[Route("FindByProductId")]
		public ProductTechnicalDtos FindByProductId(long id)
		{
			return _ProductTechnicalService.FindByProductId(id);
		}
		#endregion
	}
}