using Rosentis.DataContract.AuthEntities;
using Rosentis.DataContract.Products;
using Rosentis.DataContract.Products.Dtos;
using Rosentis.ServiceContract.AuthEntities;
using Rosentis.ServiceContract.Products;
using System;
using System.IO;
using System.Collections;
using Microsoft.AspNet.Identity;
using System.Security.Claims;
using System.Web;
using System.Web.Http;
using System.Linq;
using Rosentis.Core;
using Rosentis.Api.JsonWebTokenConfig;

namespace Rosentis.Api.Controllers.Products
{
	[RoutePrefix("api/Products")]
	public class ProductController : ApiController
	{
		#region Propertises
		private IProductService _ProductService;
		public Func<IUsersApplicationService> UsersService { set; get; }
		#endregion

		#region Ctors
		public ProductController(IProductService ProductService)
		{
			_ProductService = ProductService;
		}
		#endregion

		#region Methods
		[HttpPost]
		[Route("FindAll")]
		public ProductDtos FindAll(SpecificationOfDataList<ProductDto> request)
		{
			var identity = (ClaimsIdentity)User.Identity;
			var items = new ProductDtos();
			var user = new UserDto();
			if (identity.IsAuthenticated)
			{
				var userId = long.Parse(identity.FindFirst(ClaimTypes.UserData).Value);
				user = UsersService().Find(userId);
			}
			//if (user.Roles.Any(x => x.Name == "Supplier"))
			//{
			//var supplier = _supplierApplicationService.FindByUserId(user.Id);
			//if (supplier == null)
			//{
			//	items.AddException(new ExceptionDto()
			//	{
			//		Id = 1,
			//		Message = "دسترسی غیر مجاز",
			//		Title = "خطای اعتبار سنجی",
			//	});
			//	return items;
			//}
			//request.FilterSpecifications.Add(new FilterSpecification<ProductDto>()
			//{
			//	FilterOperation = FilterOperations.Equal,
			//	FilterValue = supplier.Id,
			//	PropertyName = "SupplierId"
			//});
			if (request != null)
			{
				request.FilterSpecifications.Add(new FilterSpecification<ProductDto>()
				{
					FilterOperation = FilterOperations.Equal,
					FilterValue = false,
					PropertyName = "IsRemoved"
				});
			}
				
			//}
			items = _ProductService.FindAll(request);
			//string baseUri = Request.RequestUri.AbsoluteUri.Replace(Request.RequestUri.PathAndQuery, String.Empty) + "/" + Request.RequestUri.Segments[1];
			//baseUri += Constants.ProductPhoto;
			//foreach (var item in items.Products)
			//{
			//	item.Picture = baseUri + item.Picture;
			//	foreach (var image in item.Images)
			//	{
			//		image.Photo = baseUri + image.Photo;
			//	}
			//}
			return items;
		}
		[HttpPost]
		[Route("FindByProductCategoryId")]
		public ProductDtos FindByProductCategoryId(long id)
		{
			return _ProductService.FindByProductCategoryId(id);
		}

		[HttpPost]
		[JwtAuthorize]
		[Route("Save")]
		public ProductDto Save(ProductDto dto)
		{
			string root = HttpContext.Current.Server.MapPath("~/Content/");
			var identity = (ClaimsIdentity)User.Identity;
			var user = new UserDto();
			if (identity.IsAuthenticated)
			{
				var userId = long.Parse(identity.FindFirst(ClaimTypes.UserData).Value);
				user = UsersService().Find(userId);
			}
			ProductDto productDto = new ProductDto();
			if (dto.Id == 0)
			{
				dto.CreatedById = user.Id;
				dto.CreatedDate = DateTime.Now;
				_ProductService.Save(dto);
				if (dto.ParentId == null)
				{
					string specificFolder = Path.Combine(root, "Products", dto.Name);
					Directory.CreateDirectory(specificFolder);

					string images = Path.Combine(specificFolder, "images");
					Directory.CreateDirectory(images);

					string thumb = Path.Combine(images, "thumb");
					Directory.CreateDirectory(thumb);

					Directory.CreateDirectory(Path.Combine(specificFolder, "catalogs"));
				}
			}
			else
			{
				var product = _ProductService.FindById(dto.Id);
				_ProductService.Save(dto);
				if (dto.ParentId == null)
				{
					//Directory.Move(root + "/" + product.Name, root + "/" + dto.Name);
				}
			}
			return productDto;
		}

		//[HttpPost]
		//[Route("Remove")]
		//public DtoResponse Remove(ProductDto dto)
		//{
		//	return _ProductService.Remove(dto);
		//}

		[HttpPost]
		[Route("FindById")]
		public ProductDto FindById(long id)
		{
			return _ProductService.FindById(id);
		}
		#endregion
	}
}