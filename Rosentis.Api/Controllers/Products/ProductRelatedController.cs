using Rosentis.DataContract.Base;
using Rosentis.DataContract.Base.Dtos;
using Rosentis.DataContract.Products;
using Rosentis.DataContract.Products.Dtos;
using Rosentis.ServiceContract.Products;
using System.Web.Http;
using System.Collections;

namespace Rosentis.Api.Controllers.ProductRelateds
{
	[RoutePrefix("api/ProductRelateds")]
	public class ProductRelatedController: ApiController
	{
		#region Propertises
		private IProductRelatedService _ProductRelatedService;
		#endregion

		#region Ctors
		public ProductRelatedController(IProductRelatedService ProductRelatedService)
		{
			_ProductRelatedService = ProductRelatedService;
		}
		#endregion

		#region Methods
		[HttpPost]
		[Route("Save")]
		public ProductRelatedDto Save(ProductRelatedDto dto)
		{
			return _ProductRelatedService.Save(dto);
		}

		[HttpPost]
		[Route("Remove")]
		public DtoResponse Remove(ProductRelatedDto dto)
		{
			return _ProductRelatedService.Remove(dto);
		}

		[HttpPost]
		[Route("FindByProductId")]
		public ProductRelatedDtos FindByProductId(long id)
		{
			return _ProductRelatedService.FindByProductId(id);
		}
		#endregion
	}
}