using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rosentis.DataContract.Shop;
using Rosentis.ServiceContract.Info.Address;
using Rosentis.Common;
using Rosentis.ServiceContract.Shop;

namespace Rosentis.Site.Controllers
{
    public class CheckoutController : ApiController
	{
        private ICartApplicationService _cartApplicationService;
		private ICartItemApplicationService _cartItemApplicationService;
		//private IProductApplicationService _productApplicationService;
		//private IProductVaseApplicationService _productVaseApplicationService;
		private IProvinceService _provinceApplicationService;
		private ICityService _cityApplicationService;
		//private IInvoiceApplicationService _invoiceApplicationService;
		//private IInvoiceDetailsApplicationService _invoiceDetailsApplicationService;
		//private IProviderApplicationService _providerApplicationService;
		//private IPurchaseApplicationService _purchaseApplicationService;
		//private ICustomerApplicationService _customerApplicationService;
		//private INotificationApplicationService _notificationApplicationService;
		//private ISmsApplicationService _smsApplicationService;
		//private IEmailApplicationService _emailApplicationService;

		public CheckoutController(
			ICartApplicationService cartApplicationService,
			ICartItemApplicationService cartItemApplicationService,
			//IProductApplicationService productApplicationService,
			//IProductVaseApplicationService productVaseApplicationService,
			IProvinceService provinceApplicationService,
			ICityService cityApplicationService
			//ICustomerApplicationService customerApplicationService,
			//IInvoiceDetailsApplicationService invoiceDetailsApplicationService,
			//IProviderApplicationService providerApplicationService,
			//IPurchaseApplicationService purchaseApplicationService,
			//INotificationApplicationService notificationApplicationService, 
			//IInvoiceApplicationService invoiceApplicationService, 
			//ISmsApplicationService smsApplicationService, 
			//IEmailApplicationService emailApplicationService
			)
		{
			_cartApplicationService = cartApplicationService;
			_cartItemApplicationService = cartItemApplicationService;
			//_productApplicationService = productApplicationService;
			//_productVaseApplicationService = productVaseApplicationService;
			_provinceApplicationService = provinceApplicationService;
			_cityApplicationService = cityApplicationService;
			//_customerApplicationService = customerApplicationService;
			//_invoiceDetailsApplicationService = invoiceDetailsApplicationService;
			//_providerApplicationService = providerApplicationService;
			//_purchaseApplicationService = purchaseApplicationService;
			//_notificationApplicationService = notificationApplicationService;
			//_invoiceApplicationService = invoiceApplicationService;
			//_smsApplicationService = smsApplicationService;
			//_emailApplicationService = emailApplicationService;
		}

		// GET: Checkout
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult Address()
		{
			if (Request.Cookies["RoseCart"] != null && !string.IsNullOrWhiteSpace(Request.Cookies["RoseCart"]["RoseCartId"]))
			{
				CustomerDto customer = new CustomerDto();
				if (Session["Customer"] != null)
				{
					customer = Session["Customer"] as CustomerDto;
				}
				List<SelectListItem> items = new List<SelectListItem>();
				items.Add(new SelectListItem { Text = "نامشخص", Value = "" });
				items.Add(new SelectListItem { Text = "آقا", Value = "آقا" });
				items.Add(new SelectListItem { Text = "خانم", Value = "خانم" });
				List<SelectListItem> provinces = new List<SelectListItem>();
				List<SelectListItem> cities = new List<SelectListItem>();
				int counter = 1;
				provinces.Add(new SelectListItem()
				{
					Text = "انتخاب کنید",
					Value = ""
				});
				cities.Add(new SelectListItem()
				{
					Text = "انتخاب کنید",
					Value = ""
				});
				foreach (var item in _provinceApplicationService.FindAll().Provinces)
				{
					provinces.Add(new SelectListItem()
					{
						Text = item.Name,
						Value = item.Id.ToString()
					});
					if (item.Id == customer.ProvinceId)
					{
						provinces[counter].Selected = true;
						var cityCounter = 1;
						foreach (var city in _cityApplicationService.FindByProvinceId(item.Id).Items)
						{
							cities.Add(new SelectListItem()
							{
								Text = city.Text,
								Value = city.Id.ToString()
							});
							if (city.Id == customer.CityId)
							{
								cities[cityCounter].Selected = true;
							}
							cityCounter++;
						}
					}
					counter++;
				}
				if (string.IsNullOrWhiteSpace(customer.Gender))
				{
					items[0].Selected = true;
				}
				else
				{
					foreach (var item in items)
					{
						if (item.Value == customer.Gender)
						{
							item.Selected = true;
							break;
						}
					}
				}
				ViewBag.Genders = items;
				ViewBag.Provinces = provinces;
				ViewBag.Cities = cities;
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
						item.Product.ParentName = parent.Product.Name;
						item.Product.UserQuantity = item.Quantity;
						item.Product.Picture = baseUri + parent.Product.Name + "/images/" + parent.Product.Images[0].Photo;
						totalPrice = totalPrice + ((int)item.Product.Price * item.Quantity);
						if (item.Product.Discount != 0)
						{
							discountPrice = discountPrice + (item.Product.Price * (((int)item.Product.Discount) / 100));
							discountPrice = discountPrice * item.Quantity;
						}
						cartItems.Add(item);
					}
					else
					{
						var isExistChilds = _cartItemApplicationService.FindChilds(item.Id);
						item.Product.UserQuantity = item.Quantity;
						if (isExistChilds.CartItems.Count == 0)
						{
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
				ViewBag.Cart = cart;
					return View(model: customer);
			}
			return Redirect("~");
		}

		[HttpPost]
		public ActionResult Address(CustomerDto model)
		{
			if (ModelState.IsValid)
			{
				//model.Province = _provinceApplicationService.Find((int)model.ProvinceId);
				//model.ProvinceName = model.Province.Name;
				//model.City = _cityApplicationService.Find((int)model.CityId);
				//model.CityName = model.City.Name;
				//Session["Customer"] = model;
				return RedirectToAction("Payment");
			}
			else
			{
				//var message = "";
				//foreach (ModelState modelState in ViewData.ModelState.Values)
				//{
				//	foreach (ModelError error in modelState.Errors)
				//	{
				//		message += error.ErrorMessage + ",";
				//	}
				//}
				//message = message.TrimEnd(',');
				//ViewBag.Message = message;
				return View();
			}
		}

		//public ActionResult Payment()
		//{
		//	if (Request.Cookies["Cart"] != null && !string.IsNullOrWhiteSpace(Request.Cookies["Cart"]["CartId"]))
		//	{
		//		CustomerDto customer = new CustomerDto();
		//		if (Session["Customer"] != null)
		//		{
		//			customer = Session["Customer"] as CustomerDto;
		//		}
		//		List<SelectListItem> items = new List<SelectListItem>();
		//		items.Add(new SelectListItem { Text = "نامشخص", Value = "" });
		//		items.Add(new SelectListItem { Text = "آقا", Value = "آقا" });
		//		items.Add(new SelectListItem { Text = "خانم", Value = "خانم" });
		//		List<SelectListItem> provinces = new List<SelectListItem>();
		//		List<SelectListItem> cities = new List<SelectListItem>();
		//		int counter = 1;
		//		provinces.Add(new SelectListItem()
		//		{
		//			Text = "انتخاب کنید",
		//			Value = ""
		//		});
		//		cities.Add(new SelectListItem()
		//		{
		//			Text = "انتخاب کنید",
		//			Value = ""
		//		});
		//		foreach (var item in _provinceApplicationService.FindAll().Provinces)
		//		{
		//			provinces.Add(new SelectListItem()
		//			{
		//				Text = item.Name,
		//				Value = item.Id.ToString()
		//			});
		//			if (item.Id == customer.ProvinceId)
		//			{
		//				provinces[counter].Selected = true;
		//				var cityCounter = 1;
		//				foreach (var city in _cityApplicationService.FindByProvinceId(item.Id).Cities)
		//				{
		//					cities.Add(new SelectListItem()
		//					{
		//						Text = city.Name,
		//						Value = city.Id.ToString()
		//					});
		//					if (city.Id == customer.CityId)
		//					{
		//						cities[cityCounter].Selected = true;
		//					}
		//					cityCounter++;
		//				}
		//			}
		//			counter++;
		//		}
		//		if (string.IsNullOrWhiteSpace(customer.Gender))
		//		{
		//			items[0].Selected = true;
		//		}
		//		else
		//		{
		//			foreach (var item in items)
		//			{
		//				if (item.Value == customer.Gender)
		//				{
		//					item.Selected = true;
		//					break;
		//				}
		//			}
		//		}
		//		ViewBag.Genders = items;
		//		ViewBag.Provinces = provinces;
		//		ViewBag.Cities = cities;
		//		var cart = _cartApplicationService.Find(Guid.Parse(Request.Cookies["Cart"]["CartId"]));
		//		Criteria criteria = new EqualCriteria()
		//		{
		//			FirstOprand = "CartId",
		//			ObjectType = typeof(string),
		//			SecondOperand = cart.Id
		//		};
		//		var cartItems = _cartItemApplicationService.FindAll(criteria, null).ToList();
		//		cart.CartItems = cartItems;
		//		var baseUri = Helpers.Api.BaseApi + Constants.ProductPhoto;
		//		foreach (var item in cart.CartItems)
		//		{
		//			item.Product.Picture = baseUri + item.Product.Picture;

		//		}
		//		ViewBag.Cart = cart;
		//		return View(model: customer);
		//	}
		//	return Redirect("~");
		//}

		//[HttpPost]
		//public ActionResult DoPayment()
		//{
		//	if (Request.Cookies["Cart"] != null && !string.IsNullOrWhiteSpace(Request.Cookies["Cart"]["CartId"]))
		//	{
		//		var suppliers = new List<SupplierDto>();
		//		var model = _cartApplicationService.Find(Guid.Parse(Request.Cookies["Cart"]["CartId"]));
		//		model.CheckedOut = true;
		//		_cartApplicationService.Save(model);
		//		var invoice = new InvoiceDto()
		//		{
		//			Id = model.Id,
		//			CreatedDate = model.CreatedDate,
		//			DueDate = DateTime.Now,
		//			InvoiceNumber = 0,
		//			Paid = true,
		//			Notes = "Zarin Pal"
		//		};
		//		Criteria criteria = new EqualCriteria()
		//		{
		//			FirstOprand = "CartId",
		//			ObjectType = typeof(string),
		//			SecondOperand = model.Id
		//		};
		//		var list = _cartItemApplicationService.FindAll(criteria, null).ToList();
		//		var invoiceDetails = new List<InvoiceDetailsDto>();
		//		string userId = "";
		//		if (model.User != null)
		//		{
		//			userId = model.User.Id.ToString();
		//		}
		//		foreach (var cartItem in list)
		//		{
		//			var title = "";
		//			decimal discount = 0;
		//			decimal price = 0;
		//			decimal priceWithDiscount = 0;
		//			string itemId = "";
		//			itemId = cartItem.ProductId.ToString();
		//			title = cartItem.Product.Name;
		//			priceWithDiscount = cartItem.PriceWithDiscount;
		//			price = cartItem.Price;
		//			discount = cartItem.Discount;
		//			cartItem.Discount = discount;
		//			cartItem.Price = price;
		//			cartItem.Quantity = 1;
		//			_cartItemApplicationService.SaveOrUpdate(cartItem);
		//			var detail = new InvoiceDetailsDto()
		//			{
		//				Discount = cartItem.Discount,
		//				Id = Guid.Empty,
		//				CreatedDate = DateTime.Now,
		//				Invoice = invoice,
		//				Price = cartItem.Price,
		//				ProductNumber = itemId,
		//				Qauntity = cartItem.Quantity,
		//				Vat = cartItem.Vat,
		//				Product = cartItem.Product,
		//				ProductInvoiceTypeId = cartItem.Product.TypeId,
		//				ProductId = cartItem.ProductId,
		//				ProductName = cartItem.Product.Name,
		//			};
		//			foreach (var item in cartItem.Vases)
		//			{
		//				var vaseDetail = new InvoiceDetailsDto()
		//				{
		//					Discount = item.Discount,
		//					Id = Guid.Empty,
		//					CreatedDate = DateTime.Now,
		//					Invoice = invoice,
		//					Price = item.Price,
		//					ProductNumber = item.Id.ToString(),
		//					Qauntity = 1,
		//					Vat = item.Vat,
		//					Vase = item,
		//					VaseId = item.Id,
		//					ProductInvoiceTypeId = 4,
		//					ProductName = item.Name,
		//				};
		//				invoiceDetails.Add(vaseDetail);

		//			}
		//			//invoice.InvoiceDetails.Add(detail);
		//			invoiceDetails.Add(detail);
		//		}
		//		invoice.Customer = new CustomerDto();
		//		if (Session["Customer"] != null)
		//		{
		//			invoice.Customer = Session["Customer"] as CustomerDto;
		//		}
		//		if (IsAuthenticated)
		//		{
		//			invoice.UserId = UserId;
		//		}
		//		invoice.PurchaseType = "ByCart";
		//		invoice = _invoiceApplicationService.Save(invoice);

		//		foreach (var invoiceDetail in invoiceDetails)
		//		{
		//			string title = "";
		//			invoiceDetail.InvoiceId = invoice.Id;
		//			_invoiceDetailsApplicationService.Save(invoiceDetail);
		//			var provider = new ProviderDto()
		//			{
		//				Id = invoiceDetail.Id,
		//				CreatedDate = DateTime.Now,
		//			};
		//			var supplier = new SupplierDto();
		//			if (invoiceDetail.ProductInvoiceTypeId != 4)
		//			{
		//				provider.SupplierId = invoiceDetail.Product.SupplierId;
		//				supplier = invoiceDetail.Product.Supplier;
		//			}
		//			else if (invoiceDetail.ProductInvoiceTypeId == 4)
		//			{
		//				provider.SupplierId = invoiceDetail.VaseId;
		//				supplier = invoiceDetail.Vase.Supplier;
		//			}
		//			if (suppliers.FirstOrDefault(x => x.Id == supplier.Id) == null)
		//			{
		//				suppliers.Add(supplier);
		//			}
		//			provider.SupplierName = supplier.CompanyName;
		//			provider.Address = supplier.Address1 + " " + supplier.Address2;
		//			provider.Cell = supplier.Phone.ToString();
		//			provider.Email = supplier.Email;
		//			provider.CreatedDate = DateTime.Now;
		//			provider = _providerApplicationService.Save(provider);
		//			int commision = 0;
		//			var purchase = new PurchaseDto()
		//			{
		//				Id = provider.Id,
		//				Discount = invoiceDetail.Discount,
		//				CreatedDate = DateTime.Now,
		//				Notes = "Zarin Pal",
		//				Price = invoiceDetail.Price,
		//				Vat = invoiceDetail.Vat,
		//				Qauntity = invoiceDetail.Qauntity,
		//				ProductNumber = invoiceDetail.ProductNumber,
		//				PurchaseTypeId = 1,
		//				Invoice = invoice,
		//				Provider = provider,
		//				CommisionPercentage = commision,
		//				InvoiceId = invoice.Id,
		//				ProviderId = provider.Id
		//			};
		//			_purchaseApplicationService.Save(purchase);
		//			var json = "{" +
		//					   "\"controller\":\"Order\"," +
		//					   "\"action\":\"\"," +
		//					   "\"id\":\"" + invoice.Id + "\"" +
		//					   "\"title\":\"سفارش محصول\"" +
		//					   "\"icon\":\"fa-shopping-cart\"" +
		//					   "\"label\":\"label-success\"" +
		//					   "}";
		//			var notification = new NotificationDto()
		//			{
		//				UserId = supplier.UserId,
		//				Content = json,
		//				CreatedDate = DateTime.Now,
		//				IsChecked = false,
		//				CheckedDate = null,
		//			};
		//			notification.UserId = 1;
		//			_notificationApplicationService.Save(notification);
		//		}
		//		var cookie = new HttpCookie("Cart");
		//		cookie.Expires = DateTime.Now.AddDays(-1);
		//		Response.Cookies.Add(cookie);
		//		Request.Cookies.Add(cookie);

		//		foreach (var item in invoiceDetails)
		//		{
		//			invoice.InvoiceDetails.Add(item);
		//		};
		//		var result = _emailApplicationService.SendMessage(invoice.Customer.Email, "فاکتور شماره " + invoice.InvoiceNumber, invoice.Customer.Name + " عزیز: <br/> فاکتور خرید شما به شرح ذیل است: <br/>" + MvcHelper.Partial("~/Views/Order/_Invoice.cshtml", invoice, ControllerContext));
		//		foreach (var item in suppliers)
		//		{
		//			var indivInvoice = new InvoiceDto()
		//			{
		//				CreatedDate = DateTime.Now,
		//				Customer = invoice.Customer,
		//				CustomerId = invoice.CustomerId,
		//				DueDate = invoice.DueDate,
		//				InvoiceNumber = invoice.InvoiceNumber,
		//				Notes = invoice.Notes,
		//				Paid = true,
		//				UserId = item.UserId,
		//				PurchaseType = invoice.PurchaseType,
		//				User = item.User
		//			};
		//			indivInvoice.Customer.Id = Guid.Empty;
		//			indivInvoice = _invoiceApplicationService.Save(indivInvoice);
		//			var indivInvoiceDetails = invoiceDetails.ToList();

		//			foreach (var detail in indivInvoiceDetails)
		//			{
		//				if ((detail.Product != null && detail.Product.SupplierId == item.Id) ||
		//					(detail.Vase != null && detail.Vase.SupplierId == item.Id))
		//				{
		//					detail.Id = Guid.Empty;
		//					detail.InvoiceId = indivInvoice.Id;
		//					_invoiceDetailsApplicationService.Save(detail);
		//				}
		//			}
		//			var json = "{" +
		//					   "\"controller\":\"Order\"," +
		//					   "\"action\":\"\"," +
		//					   "\"id\":\"" + indivInvoice.Id + "\"" +
		//					   "\"title\":\"سفارش محصول\"" +
		//					   "\"icon\":\"fa-shopping-cart\"" +
		//					   "\"label\":\"label-success\"" +
		//					   "}";
		//			var notification = new NotificationDto()
		//			{
		//				UserId = item.UserId,
		//				Content = json,
		//				CreatedDate = DateTime.Now,
		//				IsChecked = false,
		//				CheckedDate = null,
		//			};
		//			_notificationApplicationService.Save(notification);
		//			var result2 = _emailApplicationService.SendMessage(item.Email, "فاکتور شماره " + invoice.InvoiceNumber, invoice.Customer.Name + " عزیز: <br/> فاکتور خرید شما به شرح ذیل است: <br/>" + MvcHelper.Partial("~/Views/Order/_Invoice.cshtml", invoice, ControllerContext));
		//		}

		//		return Redirect("~/Orders/Invoice/" + invoice.Id);
		//	}
		//	return Redirect("~/Orders");
		//}
	}
}