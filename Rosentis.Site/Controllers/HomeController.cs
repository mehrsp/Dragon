using Rosentis.Common;
using Rosentis.DataContract.Brands.Dtos;
using Rosentis.DataContract.Products;
using Rosentis.DataContract.Products.Dtos;
using Rosentis.DataContract.Slides.Dtos;
using Rosentis.ServiceContract.Brands;
using Rosentis.ServiceContract.Products;
using Rosentis.ServiceContract.Slides;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Rosentis.Site.Controllers
{
	public class HomeController : Controller
	{
		#region Propertieses
		private ISlideShowService _slideShowService;
		private readonly IBrandService _brandService;
		private readonly IProductService _productService;

		#endregion
		#region Ctors
		public HomeController(ISlideShowService slideShowService
			, IProductService productService, IBrandService brandService
			)
		{
			_slideShowService = slideShowService;
			_productService = productService;
			_brandService = brandService;
		}
		#endregion
		#region Methods 
		public ActionResult Index()
		{
			//slide shows
			var items = _slideShowService.FindAll();
			var baseUri = Helpers.Api.BaseApi + Constants.SlideShowPhoto;
			foreach (var item in items.SlideShows)
			{
				item.Photo = baseUri + item.Photo;
			}
			ViewBag.Slides = items;

			//product news
			var products = _productService.FindNews();
			baseUri = Helpers.Api.BaseApi + Constants.ProductPhoto;
			foreach (var item in products.Products)
			{
				item.Picture = baseUri + item.Name + "/images/" + item.Images[0].Photo;
			}
			ViewBag.ProductsNew = products;

			//product sells
			products = _productService.FindMostSells();
			baseUri = Helpers.Api.BaseApi + Constants.ProductPhoto;
			foreach (var item in products.Products)
			{
				item.Picture = baseUri + item.Name + "/images/" + item.Images[0].Photo;
			}
			ViewBag.productsSells = products;

			//product Populars
			products = _productService.FindPopulars();
			baseUri = Helpers.Api.BaseApi + Constants.ProductPhoto;
			foreach (var item in products.Products)
			{
				item.Picture = baseUri + item.Name + "/images/" + item.Images[0].Photo;
			}
			ViewBag.ProductsPopulars = products;

			//special brands
			baseUri = Helpers.Api.BaseApi + Constants.BrandLogo;
			var specialBrands = _brandService.FindSpecials();
			foreach (var item in specialBrands.Brands)
			{
				item.Logo = baseUri + item.Logo;
			}
			ViewBag.SpecialBrands = specialBrands;
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			return View();
		}
		#endregion
	}
}