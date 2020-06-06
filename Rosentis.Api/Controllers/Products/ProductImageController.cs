using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Web;
using System.Web.Hosting;
using System.Web.Http;
using System.Web.Mvc;
using Newtonsoft.Json;
using Rosentis.ServiceContract.Products;
using Rosentis.ServiceContract.AuthEntities;
using Rosentis.DataContract.Products;
using Rosentis.Api.Models;
using Rosentis.Api.Helper;
using System.IO;
using Rosentis.DataContract.AuthEntities;
using Rosentis.DataContract.Base;
using Rosentis.DataContract.Products.Dtos;
using Rosentis.Api.JsonWebTokenConfig;

namespace Rosentis.Api.Controllers.Products
{
	[System.Web.Http.RoutePrefix("api/ProductImages")]
	public class ProductImageController : ApiController
	{
		#region Propertises
		private IProductImageService _ProductImageService;
		private IProductService _ProductService;
		public Func<IUsersApplicationService> UsersService { set; get; }

		#endregion

		#region Ctors
		public ProductImageController(IProductImageService ProductImageService,IProductService ProductService)
		{
			_ProductImageService = ProductImageService;
			_ProductService = ProductService;
		}
		#endregion

		#region Methods

		[System.Web.Http.HttpPost]
		[System.Web.Http.Route("Save")]
		public async System.Threading.Tasks.Task<HttpResponseMessage> Save()
		{
			var dto = new ProductImageDto();

			var uploadResult = new FileUploadResult();
			var resp = new HttpResponseMessage();
			var httpRequest = HttpContext.Current.Request;
			var identity = (ClaimsIdentity)User.Identity;
			var user = new UserDto();
			if (identity.IsAuthenticated)
			{
				var userId = long.Parse(identity.FindFirst(ClaimTypes.UserData).Value);
				user = UsersService().Find(userId);
			}

			string root = HttpContext.Current.Server.MapPath("~/App_Data");
			var provider = new MultipartFormDataStreamProvider(root);
			await Request.Content.ReadAsMultipartAsync(provider);
			var json = provider.FormData["data"];
			dto = (ProductImageDto)JsonConvert.DeserializeObject(json, typeof(ProductImageDto));
			var product = _ProductService.FindById(dto.ProductId);

			//insert document physical in system
			uploadResult = UploadHelper.Upload(Request,Path.Combine(Rosentis.Common.Helper.Common.BlobPath, "Products", product.Name, "images"));


			if (uploadResult.IsUploaded)
			{
				dto.Photo = uploadResult.FileName;
			}
			resp.Content = uploadResult.IsUploaded ? new StringContent(JsonConvert.SerializeObject(dto)) : new StringContent(JsonConvert.SerializeObject(uploadResult));

			//insert product catalog
			_ProductImageService.Save(dto);

			//returning result
			resp = new HttpResponseMessage()
			{
				Content = new StringContent(JsonConvert.SerializeObject(dto))
			};
			resp.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
			return resp;
		}

		[System.Web.Http.HttpPost]
		[System.Web.Http.Route("Remove")]
		public DtoResponse Remove(ProductImageDto dto)
		{
			var product = _ProductService.FindById(dto.ProductId);
			var resp = _ProductImageService.Remove(dto);
			
			if (System.IO.File.Exists(HostingEnvironment.MapPath(Path.Combine(Rosentis.Common.Helper.Common.BlobPath, product.Name, dto.Photo)))) {
				System.IO.File.Delete(HostingEnvironment.MapPath(Path.Combine(Rosentis.Common.Helper.Common.BlobPath, product.Name, dto.Photo)));
			}

			if (System.IO.File.Exists(HostingEnvironment.MapPath(Path.Combine(Rosentis.Common.Helper.Common.BlobPath, product.Name, "thumb" , dto.Photo))))
			{
				System.IO.File.Delete(HostingEnvironment.MapPath(Path.Combine(Rosentis.Common.Helper.Common.BlobPath, product.Name, "thumb", dto.Photo)));
			}
			return resp;
		}

		[System.Web.Http.HttpPost]
		[System.Web.Http.Route("FindByProductId")]
		public ProductImageDtos FindByProductId(long id)
		{
			return _ProductImageService.FindByProductId(id);
		}
		

		#endregion
	}
}