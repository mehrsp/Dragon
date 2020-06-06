using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rosentis.DataContract.Shop;
using Rosentis.ServiceContract.Shop;
using Rosentis.ServiceContract.Products;
using Rosentis.Common;
using System.Collections.Generic;

namespace Rosentis.Site.Controllers
{
    public class CartController : ApiController
    {
		private ICartApplicationService _cartApplicationService;
		private ICartItemApplicationService _cartItemApplicationService;
		private IProductService _productApplicationService;

		public CartController(ICartApplicationService cartApplicationService,
			 ICartItemApplicationService cartItemApplicationService,
             IProductService productApplicationService
			)
		{
			_cartApplicationService = cartApplicationService;
			_cartItemApplicationService = cartItemApplicationService;
			_productApplicationService = productApplicationService;
		}
		[HttpPost]
		public ActionResult AddToCart(AddToCartRequestDto model)
		{
			var cart = new CartDto()
			{
				CreatedDate = DateTime.Now,
			};
			var test = Request.Cookies["RoseCart"];
			if (Request.Cookies["RoseCart"] != null && !string.IsNullOrWhiteSpace(Request.Cookies["RoseCart"]["RoseCartId"]))
			{
				cart = _cartApplicationService.Find(Guid.Parse(Request.Cookies["RoseCart"]["RoseCartId"]));
			}
			else
			{
				cart = _cartApplicationService.Save(cart);
				HttpCookie myCookie = new HttpCookie("RoseCart");
				myCookie["RoseCartId"] = cart.Id.ToString();
				myCookie.Expires = DateTime.Now.AddYears(1);
				Response.Cookies.Add(myCookie);
			}

			var product = _productApplicationService.FindById(model.ProductId);

			var cartItem = _cartItemApplicationService.FindByProductId(cart.Id, model.ProductId);
			if (cartItem != null)
			{
				cartItem.Quantity += model.Quantity;
			}
			else
			{
				cartItem = new CartItemDto()
				{
					CartId = cart.Id,
					ProductId = model.ProductId,
					Price = product.Price,
					Vat = 0,
					Discount = product.Discount,
					Notes = model.Notes,
					Quantity = model.Quantity,
					CreatedDate = DateTime.Now
				};
			}
			var parentCartItem = _cartItemApplicationService.SaveOrUpdate(cartItem);

			//if product has childs or detail product have sizes and color then save all carts if they quantity are not zero
			if (model.Children != null)
			{
				foreach (var rec in model.Children)
				{
					if (rec.Quantity != 0)
					{
						var cartIt = _cartItemApplicationService.FindByProductId(cart.Id, rec.ProductId);
						if (cartIt == null)
						{
							var productDetail = _productApplicationService.FindByChildId(rec.ProductId);
							cartIt = new CartItemDto()
							{
								CartId = cart.Id,
								ProductId = rec.ProductId,
								Price = productDetail.Price,
								Vat = 0,
								Discount = productDetail.Discount,
								Notes = rec.Notes,
								Quantity = rec.Quantity,
								CreatedDate = DateTime.Now,
								ParentId = parentCartItem.Id
							};
							
						}
						else
						{
							cartIt.Quantity += rec.Quantity;
						}
						_cartItemApplicationService.SaveOrUpdate(cartIt);

					}					
				}
			}
			return RedirectToAction("Index");
		}
		[HttpPost]
		public ActionResult RemoveFromCart(string id)
		{
			var gid = Guid.Parse(id);
			var dto = _cartItemApplicationService.Find(gid);
			var childs = _cartItemApplicationService.FindChilds(gid).CartItems;
			foreach (var rec in childs) {
				_cartItemApplicationService.Remove(rec);
			}
			_cartItemApplicationService.Remove(dto);
			return Content("1");
		}
		[HttpPost]
		public ActionResult RemoveFromCartItem(string id)
		{
			var gid = Guid.Parse(id);
			var dto = _cartItemApplicationService.Find(gid);
			_cartItemApplicationService.Remove(dto);
			return Content("1");
		}

		public ActionResult Index()
		{
			if (Request.Cookies["RoseCart"] != null && !string.IsNullOrWhiteSpace(Request.Cookies["RoseCart"]["RoseCartId"]))
			{
				var cart = _cartApplicationService.Find(Guid.Parse(Request.Cookies["RoseCart"]["RoseCartId"]));				
				var baseUri = Helpers.Api.BaseApi + Constants.ProductPhoto;
				var cartItems = new List<CartItemDto>();
				var totalPrice = 0;
				decimal discountPrice = 0;
				foreach (var item in cart.CartItems)
				{
					if (item.ParentId != Guid.Empty)
					{
						var parent = _cartItemApplicationService.Find(item.ParentId);
						item.Product.UserQuantity = item.Quantity;
						item.Product.Name = parent.Product.Name + "<br/>" + item.Product.Name;
						item.Product.Picture = baseUri + parent.Product.Name + "/images/" + parent.Product.Images[0].Photo;
						totalPrice = totalPrice + ((int)item.Product.Price * item.Quantity);
						if (item.Product.Discount != 0) {
							discountPrice = discountPrice + (item.Product.Price * (((int)item.Product.Discount) / 100));
							discountPrice = discountPrice * item.Quantity;
						}						
						cartItems.Add(item);
					}
					else 
					{
						var isExistChilds = _cartItemApplicationService.FindChilds(item.Id);
						item.Product.UserQuantity = item.Quantity;
						if (isExistChilds.CartItems.Count == 0) {
							item.Product.Picture = baseUri + item.Product.Name + "/images/" + item.Product.Images[0].Photo;
							totalPrice = totalPrice + ((int)item.Product.Price * item.Quantity);
							if (item.Product.Discount != 0)
							{
								discountPrice = (decimal)discountPrice + (item.Product.Price * ((item.Product.Discount) / 100));
								discountPrice = discountPrice * item.Quantity;
							}
							
							cartItems.Add(item);
						}
					}
				}
				ViewBag.TotalPrice = totalPrice - (int)discountPrice;
				ViewBag.TotalPriceStr = (totalPrice - (int)discountPrice).ToString("#,##0") + " تومان";
				ViewBag.TotalPriceWithoutDiscount = totalPrice;
				ViewBag.TotalPriceWithoutDiscountStr = totalPrice.ToString("#,##0") + " تومان";
				ViewBag.DiscountPrice = (int)discountPrice;
				ViewBag.DiscountPriceStr = ((int)discountPrice).ToString("#,##0") + " تومان";
				cart.CartItems = new List<CartItemDto>();
				cart.CartItems = cartItems;	
				return View(model: cart);
			}
			else
			{
				return View(new CartDto());
			}
		}
	}
}