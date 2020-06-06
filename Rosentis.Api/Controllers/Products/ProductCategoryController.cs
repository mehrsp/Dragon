using Rosentis.DataContract.Base;
using Rosentis.DataContract.Base.Dtos;
using Rosentis.DataContract.Products;
using Rosentis.DataContract.Products.Dtos;
using Rosentis.Api.Models;
using Rosentis.ServiceContract.Products;
using System.Collections.Generic;
using System.Web;
using System.Web.Http;
using System;
using Rosentis.ServiceContract.AuthEntities;
using System.Security.Claims;
using Rosentis.DataContract.AuthEntities;
using System.Collections;

namespace Rosentis.Api.Controllers.Products
{
	[RoutePrefix("api/ProductCategories")]
	public class ProductCategoryController : ApiController
	{
		private IProductCategoryService _ProductCategoryService;
		public Func<IUsersApplicationService> UsersService { set; get; }


		public ProductCategoryController(IProductCategoryService ProductCategoryService)
		{
			_ProductCategoryService = ProductCategoryService;
		}

		[HttpPost]
		[Route("FindAll")]
		public ProductCategoryDataDtos FindAll()
		{
			return _ProductCategoryService.FindAll();
		}

		[HttpPost]
		[Route("FillDropBox")]
		public DropBoxDtos FillDropBox()
		{
			return _ProductCategoryService.FillDropBox();
		}

		[HttpPost]
		[Route("Save")]
		public ProductCategoryDataDto Save(ProductCategoryDto dto)
		{
			string root = HttpContext.Current.Server.MapPath("~/Content/");
			var identity = (ClaimsIdentity)User.Identity;
			var user = new UserDto();
			if (identity.IsAuthenticated)
			{
				var userId = long.Parse(identity.FindFirst(ClaimTypes.UserData).Value);
				user = UsersService().Find(userId);
			}
			dto.CreatedById = user.Id;
			return _ProductCategoryService.Save(dto);
		}

		[HttpPost]
		[Route("Remove")]
		public DtoResponse Remove(ProductCategoryDto dto)
		{
			return _ProductCategoryService.Remove(dto);
		}

		[HttpPost]
		[Route("FindById")]
		public ProductCategoryDto FindById(int? id)
		{
			return _ProductCategoryService.FindById(id);
		}

	}
}