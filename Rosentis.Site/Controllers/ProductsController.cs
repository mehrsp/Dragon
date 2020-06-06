using Rosentis.Common;
using Rosentis.Core.Filtering;
using Rosentis.DataContract.Brands;
using Rosentis.DataContract.Brands.Dtos;
using Rosentis.DataContract.Info.Address;
using Rosentis.DataContract.Info.Address.Dtos;
using Rosentis.DataContract.Products;
using Rosentis.DataContract.Products.Dtos;
using Rosentis.DomainModel.Products;
using Rosentis.ServiceContract.Brands;
using Rosentis.ServiceContract.Info.Address;
using Rosentis.ServiceContract.Products;
using Rosentis.ServiceContract.Users;
using Rosentis.Site.Jwt;
using Rosentis.Site.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace Rosentis.Site.Controllers
{
    public class ProductsController : Controller
    {
		#region Propertieses 
		private readonly IProductService _productService;
		private readonly IMemberService _memberApplicationService;
		private readonly IProductCategoryService _productCategoryService;
		private readonly IProductCategoryTechnicalService _productCategoryTechnicalService;
		private readonly IBrandService _brandService;
		private readonly ITechnicalService _technicalService;
		private readonly ICountryService _countryService;
		#endregion

		#region Ctors		
		public ProductsController(IProductService productService, IMemberService memberApplicationService, 
			IProductCategoryService productCategoryService, IProductCategoryTechnicalService productCategoryTechnicalService,
			IBrandService brandService,
			ITechnicalService technicalService,
			ICountryService countryService)
		{
			_productService = productService;
			_memberApplicationService = memberApplicationService;
			_productCategoryService = productCategoryService;
			_productCategoryTechnicalService = productCategoryTechnicalService;
			_technicalService = technicalService;
			_brandService = brandService;
			_countryService = countryService;
		}
		#endregion

		#region Methods
		public ActionResult Index()
		{
			return View();
		}

		[HttpPost]
		[JwtAuthorize]
		[AllowAnonymous]
		public ActionResult DoFavorite(long id)
		{
			if (Session["UserId"] != null)
			{
				var userId = long.Parse(Session["UserId"].ToString());
				var result = _memberApplicationService.DoFavorite(userId, id);
				if (result) return Content("1");
				else return Content("2");
			}
			else
			{
				return Content("0");
			}
		}
		[HttpPost]
		[JwtAuthorize]
		[AllowAnonymous]
		public ActionResult DoLike(long id)
		{
			if (Session["UserId"] != null)
			{
				var userId = long.Parse(Session["UserId"].ToString());
				var result = _memberApplicationService.DoLike(userId, id);
				if (result) return Content("1");
				else return Content("2");
			}
			else
			{
				return Content("0");
			}
		}
		[HttpPost]
		public double CheckQuantity(long id)
		{
			var test = _productService.CheckQuantity(id);
			return test;
		}
		public ActionResult List(int categoryId = 0, string orderBy = "",
			                     int page = 0, 
								 List<int> filters = null,
								 List<int> brands = null,
								 List<int> countries = null,
								 int onSale = 0, int inStock = 0,
								 int min_price = 0, int max_price = 0)
		{
			//create filter and sort model
			var filterModel = new FilterModel();
			
			//user request
			var test = orderBy;
			var test2 = new List<int>();
			test2 = filters;
			var request = new GridRequest();
			var ids = "";

			//sorts
			if (test == null || test == "")
			{
				test = "D";
			}
			filterModel.OrderBy = test;
			List<GridSort> gridsort = new List<GridSort>();
			switch (test)
			{
				case "S":
					gridsort.Add(new GridSort { Dir = "asc", Field = "SoldCount" });
					break;
				case "R":
					gridsort.Add(new GridSort { Dir = "asc", Field = "Ranking" });
					break;
				case "D":
					gridsort.Add(new GridSort { Dir = "asc", Field = "CreatedDate" });
					break;
				default:
					gridsort.Add(new GridSort { Dir = "asc", Field = "CreatedDate" });
					break;
			}

			request = FilterHelper.AddCustomSort(request, gridsort);

			//filter
			string filerString = "";
			string brandFilterSting = "";
			string countryFilterSting = "";

			//filters in url & add filters to repository
			request.Filter = new GridFilter();
			request.Filter.Filters = new List<GridFilter>();

			//if set category id then fetch all products in category else fetch all
			//find if select parent categories
			//navigation string
			var filterCategory = new FilterCategoryChild();
			if (categoryId != 0) {
				var categories = _productCategoryService.FindById(categoryId);
				if (categories.Children.Count == 0)
				{
					Expression<Func<Product, bool>> category = x => x.ProductCategoryId == categoryId;
					var categoryFilter = new GridFilter()
					{
						perdict = category
					};
					request.Filter.Filters.Add(categoryFilter);
					filterCategory.Categories.Add(categories);
				}
				else
				{
					filterCategory.list = new List<int>();
					var categoryIdList = _addChildsToFilter(categories, request, filterCategory);
					for (var i =0; i <= categoryIdList.list.Count-1; i++) {
						if (i == categoryIdList.list.Count - 1)
						{
							ids += categoryIdList.list[i].ToString();
						}
						else
						{
							ids += categoryIdList.list[i].ToString() + ",";
						}
					}
				}
				filterCategory.OriginalCategory = categories;
				filterCategory.Categories = _productService.FindCategoriesWithParent(categories);
				filterModel.FilterCategoryChild = filterCategory;
			}			

			//add filter for inStock
			if (inStock == 1)
			{
				System.Linq.Expressions.Expression<Func<Product, bool>> inStockPerdict = x => x.Quantity > 0;
				var inStockFilter = new GridFilter()
				{
					perdict = inStockPerdict
				};
				request.Filter.Filters.Add(inStockFilter);
				filterModel.InStock = 1;
			}
			else
			{
				filterModel.InStock = 0;
			}

			//add filter for onSale
			if (onSale == 1)
			{
				Expression<Func<Product, bool>> onSalePerdict = x => x.Discount != null;
				var onSaleFilter = new GridFilter()
				{
					perdict = onSalePerdict
				};
				request.Filter.Filters.Add(onSaleFilter);
				filterModel.OnSale = 1;
			}
			else
			{
				filterModel.OnSale = 0;
			}

			//filter by min and max prices
			if (min_price != 0)
			{
				Expression<Func<Product, bool>> price = x => x.Price > min_price && x.Price < max_price;
				var priceFilter = new GridFilter()
				{
					perdict = price
				};
				request.Filter.Filters.Add(priceFilter);

				filterModel.MaxPrice = max_price;
				filterModel.MinPrice = min_price;
			}
			else
			{
				filterModel.MaxPrice = 10000000;
				filterModel.MinPrice = 1000;
			}

			//check array of filters
			if (filters == null)
			{
				filters = new List<int>();
			}
			else
			{
				var filterIndex = filters.Count + 1;
	
				for (var i = 0; i <= filters.Count-1; i++)
				{
					//add to filters
					int? val = (int?)filters[i];
					System.Linq.Expressions.Expression<Func<Product, bool>> perdict = x => x.Technicals.Select(y => y.TechnicalId).Contains(val);
					var filter = new GridFilter()
					{
						perdict = perdict
					};
					request.Filter.Filters.Add(filter);

					//add for url
					filerString = filerString + "&filters" + "=" + filters[i];
				}
				filterModel.Filters = filters;
			}
			filterModel.FilterString = filerString;

			//check array of brands
			if (brands == null)
			{
				brands = new List<int>();
			}
			else
			{
				var brandIndex = brands.Count + 1;

				for (var i = 0; i <= brands.Count - 1; i++)
				{
					//add to brands
					int? val = (int?)brands[i];
					Expression<Func<Product, bool>> perdict = x => x.BrandId == val;

					var filter = new GridFilter()
					{
						perdict = perdict

					};
					request.Filter.Filters.Add(filter);

					//add for url
					brandFilterSting = brandFilterSting + "&brands" + "=" + brands[i];
				}
				filterModel.Brands = brands;
			}
			filterModel.BrandString = brandFilterSting;

			//check array of countries
			if (countries == null)
			{
				countries = new List<int>();
			}
			else
			{
				var countryIndex = countries.Count + 1;

				for (var i = 0; i <= countries.Count - 1; i++)
				{
					//add to countries
					int? val = (int?)countries[i];
					Expression<Func<Product, bool>> perdict = x => x.Brand.CountryId == val;

					var filter = new GridFilter()
					{
						perdict = perdict

					};
					request.Filter.Filters.Add(filter);

					//add for url
					countryFilterSting = countryFilterSting + "&countries" + "=" + countries[i];
				}
				filterModel.Countries = countries;
			}
			filterModel.CountryString = countryFilterSting;

			//filter page
			request.PageSize = 9;
			if (page == 0)
			{
				request.Page = 1;
			}
			else
			{
				request.Page = (int)page;
			}
			filterModel.CurrentPage = request.Page;
			filterModel.PageCount = _productService.FindPagesNumber(categoryId);

			//products
			var products = _productService.FindAllFiltered(request, ids).Data;
			filterModel.Products = new ProductDtos()
			{
				Products = products
			};

			//images of products
			var baseUri = Helpers.Api.BaseApi + Constants.ProductPhoto;
			for (var i =0; i <= products.Count-1; i++)
			{
				products[i].Picture = baseUri + products[i].Name + "/images/" + products[i].Images[0].Photo;
			}

			//current category
			filterModel.CategoryId = categoryId;
			var productCategories = _productCategoryService.FindById(categoryId);

			//technicals
			var productCategoryTechnicals = _productCategoryTechnicalService.FindByProductCategoryId(categoryId);
			filterModel.Technicals = productCategoryTechnicals;

			//technical and brand and country chooses by user
			var technicalChooses = new TechnicalDtos();
			technicalChooses.Technicals = new List<TechnicalDto>();
			filterModel.TechnicalChooses = technicalChooses;

			var brandChooses = new BrandDtos();
			brandChooses.Brands = new List<BrandDto>();
			filterModel.BrandChooses = brandChooses;

			var countryChooses = new CountryDtos();
			countryChooses.Countries = new List<CountryDto>();
			filterModel.CountryChooses = countryChooses;

			if (filters != null)
			{
				foreach (var rec in filters)
				{
					var tec = _technicalService.FindById(rec);
					technicalChooses.Technicals.Add(tec);
				}
				filterModel.TechnicalChooses = technicalChooses;
			}
			
			if (brands != null)
			{
				foreach (var rec in brands)
				{
					var tec = _brandService.FindById(rec);
					brandChooses.Brands.Add(tec);
				}
				filterModel.BrandChooses = brandChooses;
			}

			if (countries != null && countries.Count != 0)
			{
				foreach (var rec in countries)
				{
					var tec = _countryService.FindById(rec);
					countryChooses.Countries.Add(tec);
				}
				filterModel.CountryChooses = countryChooses;
			}

			//set filter model view bag
			ViewBag.FilterModel = filterModel;
			return View();
		}

		public ActionResult Detail(long id)
		{
			var product = _productService.FindById(id);
			var baseUri = Path.Combine(Helpers.Api.BaseApi, Constants.ProductPhoto, product.Name);
			if (product.Images.Count != 0)
			{
				foreach (var image in product.Images)
				{
					image.Photo = baseUri + "/images/" + image.Photo;
				}
			}
			return View(product);
		}
		#endregion

		#region Functions
		public FilterCategoryChild _addChildsToFilter(ProductCategoryDto categories, GridRequest request, FilterCategoryChild filterCategory)
		{
			foreach (var rec in categories.Children)
			{
				if (rec.Children.Count == 0)
				{
					filterCategory.list.Add(rec.Id);
				}
				else
				{
					_addChildsToFilter(rec, request, filterCategory);
				}		
			}
			return filterCategory;
		}

		#endregion
	}
}