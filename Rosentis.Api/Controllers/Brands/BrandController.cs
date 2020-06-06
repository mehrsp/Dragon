using System;
using Rosentis.DataContract.Base;
using Rosentis.DataContract.Base.Dtos;
using Rosentis.DataContract.Brands;
using Rosentis.DataContract.Brands.Dtos;
using Rosentis.ServiceContract.AuthEntities;
using Rosentis.ServiceContract.Brands;
using System.Web.Http;
using Rosentis.Api.JsonWebTokenConfig;
using Rosentis.DataContract.AuthEntities;
using System.Security.Claims;
using System.Net.Http;
using Rosentis.Api.Models;
using System.Web;
using Newtonsoft.Json;
using Rosentis.Api.Helper;
using System.IO;
using System.Net.Http.Headers;

namespace Rosentis.Api.Controllers.Brands
{
	[RoutePrefix("api/Brands")]
	public class BrandsController: ApiController
	{
		#region Propertises
		public Func<IUsersApplicationService> UsersService { set; get; }
		private IBrandService _BrandService;
		#endregion

		#region Ctors
		public BrandsController(IBrandService BrandService)
		{
			_BrandService = BrandService;
		}
		#endregion

		#region Methods
		[HttpPost]
		public BrandDtos FindAll()
		{
			return _BrandService.FindAll();
		}
		[HttpGet]
		public string Test()
		{
			return "test";
		}
		[HttpPost]
		public DropBoxDtos FillDropBox()
		{
			return _BrandService.FillDropBox();
		}


		[HttpPost]
		//[JwtAuthorize(Roles = "Admin")]
		public async System.Threading.Tasks.Task<HttpResponseMessage> Save()
		{
			var dto = new BrandDto();

			var uploadResult = new FileUploadResult();
			var resp = new HttpResponseMessage();

			var httpRequest = HttpContext.Current.Request;
			
			string root = HttpContext.Current.Server.MapPath("~/App_Data");
			var provider = new MultipartFormDataStreamProvider(root);
			await Request.Content.ReadAsMultipartAsync(provider);
			var json = provider.FormData["data"];
			dto = (BrandDto)JsonConvert.DeserializeObject(json, typeof(BrandDto));
			
			//insert document physical in system
			uploadResult = UploadHelper.Upload2(Request, Path.Combine(Rosentis.Common.Helper.Common.BlobPath, "Brands/"));
			if (uploadResult.IsUploaded)
			{
				dto.Logo = uploadResult.FileName;
			}
			resp.Content = uploadResult.IsUploaded ? new StringContent(JsonConvert.SerializeObject(dto)) : new StringContent(JsonConvert.SerializeObject(uploadResult));

			//insert product catalog
			_BrandService.Save(dto);

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
		public DtoResponse Remove(BrandDto dto)
		{
			return _BrandService.Remove(dto);
		}

		[HttpPost]
		[Route("FindById")]
		public BrandDto FindById(long id)
		{
			return _BrandService.FindById(id);
		}
		#endregion
	}
}