using Rosentis.Common;
using Rosentis.DataContract.Products;
using Rosentis.DataContract.Shop;
using Rosentis.ServiceContract.Products;
using Rosentis.ServiceContract.Shop;
using Rosentis.Site.Models;
using System;
using System.Web.Mvc;

namespace Rosentis.Site.Controllers
{
    public class PartialController : Controller
    {
		private IProductCategoryService _productCateogoryService;
		private ICartApplicationService _cartApplicationService;
		private ICartItemApplicationService _cartItemApplicationService;
		public PartialController(IProductCategoryService productCateogoryServicee, ICartApplicationService cartApplicationService, ICartItemApplicationService cartItemApplicationService)
		{
			_productCateogoryService = productCateogoryServicee;
			_cartApplicationService = cartApplicationService;
			_cartItemApplicationService = cartItemApplicationService;
		}

		// GET: Partial
		//[ChildActionOnly]
		public ActionResult MainMenu()
		{
			var user = new LoginModel();
			if (Session["UserId"] != null)
			{
				var test = Session["LoginUser"] as LoginModel;
				user = test;
			}
			ViewBag.User = user;
			ViewBag.Categories = _productCateogoryService.FindAll();
			string menuStr = "";
			foreach (var item in ViewBag.Categories.data)
			{
				_makeMenus(item, ref menuStr);
			}
			ViewBag.Cart = _findCartItems();
			ViewBag.Menus = menuStr;
			//Get the menuItems collection from somewhere
			return View();
		}
		private CartDto _findCartItems()
		{
			if (Request.Cookies["RoseCart"] != null && !string.IsNullOrWhiteSpace(Request.Cookies["RoseCart"]["RoseCartId"]))
			{
				var cart = _cartApplicationService.Find(Guid.Parse(Request.Cookies["RoseCart"]["RoseCartId"]));
				cart.CartItemCount = 0;
				var baseUri = Helpers.Api.BaseApi + Constants.ProductPhoto;
				
				var totalPrice = 0;
				decimal discountPrice = 0;
				foreach (var item in cart.CartItems)
				{
					if (item.ParentId == Guid.Empty)
					{
						item.Product.Picture = baseUri + item.Product.Name + "/images/" + item.Product.Images[0].Photo;
						var checkCartItemChilds = _cartItemApplicationService.FindChilds(item.Id);
						if (checkCartItemChilds.CartItems.Count == 0)
						{
							totalPrice = totalPrice + ((int)item.Product.Price * item.Quantity);
							if (item.Product.Discount != 0)
							{
								discountPrice = (decimal)discountPrice + (item.Product.Price * ((item.Product.Discount) / 100));
								discountPrice = discountPrice * item.Quantity;
							}
						}
						cart.CartItemCount += 1;
					}
					else
					{
						totalPrice = totalPrice + ((int)item.Product.Price * item.Quantity);
						if (item.Product.Discount != 0)
						{
							discountPrice = (decimal)discountPrice + (item.Product.Price * ((item.Product.Discount) / 100));
							discountPrice = discountPrice * item.Quantity;
						}
					}
				}
				cart.TotalPrice = totalPrice - (int)discountPrice;
				return cart;
			}
			else
			{
				return new CartDto();
			}
		}
		private void _makeMenus(ProductCategoryDataDto menu, ref string menuStr)
		{

			string cls = "menu-item menu-item-type-taxonomy menu-item-object-product_cat";
			string imgCls = "";
			string subMenuClass = "sub-menu sub-menu-height";
			string menuName = menu.model.Name;

			if (menu.model.ParentId == null)
			{
				cls = "menu-item menu-item-type-taxonomy menu-item-object-product_cat menu-item-has-children";
				imgCls = "<img width=\"" + 30 + "\" height=\"" + 30 + "\" " + "alt=\"" + "" + "\" data-src=\"" + "" + "\"  class=\"" + "menu-image menu-image-title-after lazyload" + "\" "
				+ "src=\"" + "" + "\" /><noscript>"
				+ "<img width = \"" + 30 + "\" height=\"" + 30 + "\" src=\"" + "" + "\" class=\"" + "menu-image menu-image-title-after" + "\"  alt=\"" + "" + "\"  /></noscript>";
				menuName = "<span class=\"" + "menu-image-title-after menu-image-title" + "\">"
				+ menu.model.Name + "</span>";
			}
			if (menu.model.Priority >= 1)
			{
				subMenuClass = "sub-menu";
				cls = "menu-item menu-item-type-custom menu-item-object-custom";
			}
			menuStr += "<li class=\"" + cls + "\">" +
				"<a href=\"" + "/Products/List/?categoryId=" + menu.model.Id + "\">" + imgCls + menuName + "</a>" +
				"<ul class=\"" + subMenuClass + "\">";
			if (menu.model.Children.Count > 0)
			{
				foreach (var child in menu.children)
				{
					_makeMenus(child, ref menuStr);
				}

			}
			menuStr += "</ul></li>";
		}


	}
}