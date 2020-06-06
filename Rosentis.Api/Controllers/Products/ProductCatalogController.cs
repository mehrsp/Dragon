using Newtonsoft.Json;
using Rosentis.DataContract.Base;
using Rosentis.DataContract.ExeptionModel;
using Rosentis.DataContract.Products;
using Rosentis.DataContract.Products.Dtos;
using Rosentis.Api.Helper;
using Rosentis.Api.Models;
using Rosentis.ServiceContract.Products;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Hosting;
using System.Web.Http;
using System.Collections;


namespace Rosentis.Api.Controllers.Products
{
	[RoutePrefix("api/ProductCatalogs")]
	public class ProductCatalogController : ApiController
	{
		#region Propertises
		private IProductCatalogService _ProductCatalogService;
		private IProductService _ProductService;
		#endregion

		#region Ctors
		public ProductCatalogController(IProductCatalogService ProductCatalogService,
			 IProductService ProductService)
		{
			_ProductCatalogService = ProductCatalogService;
			_ProductService = ProductService;
		}
		#endregion

		#region Methods
		[HttpPost]
		[Route("Test")]
		public string Test()
		{
			return "Hi";
		}

		[HttpPost]
		[Route("Save")]
		public async System.Threading.Tasks.Task<HttpResponseMessage> Save()
		{
			var dto = new ProductCatalogDto();

			var uploadResult = new FileUploadResult();
			var resp = new HttpResponseMessage();

			var httpRequest = HttpContext.Current.Request;
			var token = (httpRequest.Headers["Authorization"]);

			string root = HttpContext.Current.Server.MapPath("~/App_Data");
			var provider = new MultipartFormDataStreamProvider(root);
			await Request.Content.ReadAsMultipartAsync(provider);
			var json = provider.FormData["data"];
			dto = (ProductCatalogDto)JsonConvert.DeserializeObject(json, typeof(ProductCatalogDto));
			var product = _ProductService.FindById(dto.ProductId);

			//insert document physical in system
			uploadResult = UploadHelper.Upload(Request, 
				           Path.Combine(Rosentis.Common.Helper.Common.BlobPath, product.Name, "catalogs"));

			
			resp.Content = uploadResult.IsUploaded ? new StringContent(JsonConvert.SerializeObject(dto)) : new StringContent(JsonConvert.SerializeObject(uploadResult));

			//insert product image 
			_ProductCatalogService.Save(dto);

			//returning result
			resp = new HttpResponseMessage()
			{
				Content = new StringContent(JsonConvert.SerializeObject(dto))
			};
			resp.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
			return resp;
		}

		[HttpPost]
		[Route("Remove")]
		public DtoResponse Remove(ProductCatalogDto dto)
		{
			var product = _ProductService.FindById(dto.ProductId);
			var resp = _ProductCatalogService.Remove(dto);

			return resp;
		}

		[HttpPost]
		[Route("FindByProductId")]
		public ProductCatalogDtos FindByProductId(long id)
		{
			return _ProductCatalogService.FindByProductId(id);
		}

		[HttpPost]
		[Route("Download")]
		public HttpResponseMessage Download(ProductCatalogDto dto)
		{
			var product = _ProductService.FindById(dto.ProductId);
			return UploadHelper.Download( Path.Combine(Rosentis.Common.Helper.Common.BlobPath, product.Name, "catalogs", product.Picture), dto.Title);
		}
		#endregion
	}
}