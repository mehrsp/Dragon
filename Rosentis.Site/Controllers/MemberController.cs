using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using Rosentis.DataContract.AuthEntities;
using Rosentis.DataContract.Users;
using Rosentis.ServiceContract.AuthEntities;
using Rosentis.ServiceContract.Users;
using Rosentis.Site.Jwt;
using Rosentis.Site.Models;
using RestSharp;
using HttpCookie = System.Web.HttpCookie;
using Rosentis.ServiceContract.Info.Address;

namespace Rosentis.Site.Controllers
{
    public class MemberController : ApiController
    {
		private IUserVerificationService _userVerificationService;
		private IUsersApplicationService _usersApplicationService;
		private IMemberService _memberApplicationService;
		private ITokenStoreApplicationService _tokenStoreApplication;
		private IProvinceService _provinceApplicationService;
		private ICityService _cityApplicationService;
		private IMemberImportantDateApplicationService _memberImportantDateApplicationService;
		public MemberController(
			IUserVerificationService userVerificationService,
			IUsersApplicationService usersApplicationService,
			IMemberService memberApplicationService,
			ITokenStoreApplicationService tokenStoreApplication,
			IProvinceService provinceApplicationService,
			ICityService cityApplicationService,
			IMemberImportantDateApplicationService memberImportantDateApplicationService
			)
		{
			_userVerificationService = userVerificationService;
			_usersApplicationService = usersApplicationService;
			_memberApplicationService = memberApplicationService;
			_tokenStoreApplication = tokenStoreApplication;
			_provinceApplicationService = provinceApplicationService;
			_cityApplicationService = cityApplicationService;
			_memberImportantDateApplicationService = memberImportantDateApplicationService;
		}
		// GET: Member
		public ActionResult Index()
		{
			return View();
		}
		public ActionResult Register()
		{
			return View();
		}
		[HttpPost]
		public ActionResult Register(RegisterUserDto model)
		{
			if (ModelState.IsValid)
			{
				var member = _usersApplicationService.FindByPhone(model.Phone);
				if (member != null)
				{
					ViewBag.Message = "این شماره قبلا ثبت شده است. لطفا از دکمه ورود به سایت استفاده نمایید.";
					return View();
				}
				member = _usersApplicationService.FindByEmail(model.Email);
				if (member != null)
				{
					ViewBag.Message = "این ایمیل قبلا ثبت شده است. لطفا از دکمه ورود به سایت استفاده نمایید.";
					return View();
				}
				Session["RegisteredUser"] = model;
				_usersApplicationService.GenerateVerificationCode(model.Phone);
				return RedirectToAction("GetVerificationCode");
			}
			else
			{
				var message = "";
				foreach (ModelState modelState in ViewData.ModelState.Values)
				{
					foreach (ModelError error in modelState.Errors)
					{
						message += error.ErrorMessage + ",";
					}
				}
				message = message.TrimEnd(',');
				ViewBag.Message = message;
				return View();
			}
		}
		public ActionResult SignIn()
		{
			return View();
		}
		[HttpPost]
		public ActionResult SignIn(LoginModel model)
		{
			if (ModelState.IsValid)
			{
				//var member = _usersApplicationService.FindByPhone(model.Phone);
				//if (member == null || member.Id == 0)
				//{
				//	ViewBag.Message = "این شماره قبلا ثبت شده است. لطفا از دکمه ورود به سایت استفاده نمایید.";
				//	return View();
				//}
				Session["LoginUser"] = model;
				//_usersApplicationService.GenerateVerificationCode(model.Phone);
				var user = _usersApplicationService.FindByEmail(model.username);
				var url = Helpers.Api.BaseApi + "login";
				var client = new RestClient(url);
				var request = new RestRequest(Method.POST);
				request.AddHeader("cache-control", "no-cache");
				request.AddHeader("content-type", "application/x-www-form-urlencoded");
				request.AddParameter("application/x-www-form-urlencoded", "username=" + model.username + "&password=" + model.password + "&grant_type=password", ParameterType.RequestBody);
				IRestResponse response = client.Execute(request);
				var token = System.Web.Helpers.Json.Decode(response.Content);
				HttpCookie myCookie = new HttpCookie("UserSettings");
				myCookie["Token"] = token.access_token.ToString();
				myCookie["Title"] = user.DisplayName;
				myCookie.Expires = DateTime.Now.AddDays(365d);
				Response.Cookies.Add(myCookie);
				return RedirectToAction("Profile");
			}
			else
			{
				var message = "";
				foreach (ModelState modelState in ViewData.ModelState.Values)
				{
					foreach (ModelError error in modelState.Errors)
					{
						message += error.ErrorMessage + ",";
					}
				}
				message = message.TrimEnd(',');
				ViewBag.Message = message;
				return View();
			}
		}
		public ActionResult GetVerificationCode()
		{
			if (Session["RegisteredUser"] == null) return View(Content("Not Found"));
			return View();
		}
		[HttpPost]
		public ActionResult GetVerificationCode(UserVerifyDto model)
		{
			if (Session["RegisteredUser"] == null) return View(Content("Not Found"));
			var registerDto = Session["RegisteredUser"] as RegisterUserDto;
			var data = _userVerificationService.Find(registerDto.Phone, model.Code, true);
			if (data.Id != Guid.Empty)
			{
				var user = _usersApplicationService.FindByPhone(data.Phone);
				var member = new MemberDto();
				if (user == null || user.Id == 0)
				{
					member = _usersApplicationService.CreateMember(data.Phone);
				}
				var url = Helpers.Api.BaseApi + "login";
				var client = new RestClient(url);
				var request = new RestRequest(Method.POST);
				request.AddHeader("cache-control", "no-cache");
				request.AddHeader("content-type", "application/x-www-form-urlencoded");
				request.AddParameter("application/x-www-form-urlencoded", "phone=" + registerDto.Phone + "&code=" + model.Code + "&grant_type=password", ParameterType.RequestBody);
				IRestResponse response = client.Execute(request);
				var token = System.Web.Helpers.Json.Decode(response.Content);
				HttpCookie myCookie = new HttpCookie("UserSettings");
				myCookie["Token"] = token.access_token.ToString();
				myCookie["Title"] = "";
				myCookie.Expires = DateTime.Now.AddDays(365d);
				Response.Cookies.Add(myCookie);
				return Redirect(Url.Content("~"));
			}
			return View();
		}
		public ActionResult GetVerificationCodeForLogin()
		{
			if (Session["LoginUser"] == null) return View(Content("Not Found"));
			return View();
		}
		[HttpPost]
		public ActionResult GetVerificationCodeForLogin(UserVerifyDto model)
		{
			if (Session["LoginUser"] == null) return View(Content("Not Found"));
			var registerDto = Session["LoginUser"] as LoginModel;
			var data = _userVerificationService.Find(registerDto.Phone, model.Code, true);
			if (data.Id != Guid.Empty)
			{
				var user = _usersApplicationService.FindByPhone(data.Phone);
				var url = Helpers.Api.BaseApi + "login";
				var client = new RestClient(url);
				var request = new RestRequest(Method.POST);
				request.AddHeader("cache-control", "no-cache");
				request.AddHeader("content-type", "application/x-www-form-urlencoded");
				request.AddParameter("application/x-www-form-urlencoded", "phone=" + user.Phone + "&code=" + model.Code + "&grant_type=password", ParameterType.RequestBody);
				IRestResponse response = client.Execute(request);
				var token = System.Web.Helpers.Json.Decode(response.Content);
				HttpCookie myCookie = new HttpCookie("UserSettings");
				myCookie["Token"] = token.access_token.ToString();
				myCookie["Title"] = user.DisplayName;
				myCookie.Expires = DateTime.Now.AddDays(365d);
				Response.Cookies.Add(myCookie);
				return Redirect(Url.Content("~"));
			}
			return View();
		}
		[JwtAuthorize]
		public ActionResult Profile()
		{
			var test = Session["UserId"];
			if (Session["UserId"] == null) return RedirectToAction("SignIn");
			var userId = long.Parse(Session["UserId"].ToString());
			//var model = new ProfileAdditional();
			//model.Member = _memberApplicationService.Find(userId);
			//List<SelectListItem> items = new List<SelectListItem>();
			//items.Add(new SelectListItem { Text = "نامشخص", Value = "" });
			//items.Add(new SelectListItem { Text = "آقا", Value = "آقا" });
			//items.Add(new SelectListItem { Text = "خانم", Value = "خانم" });
			//List<SelectListItem> provinces = new List<SelectListItem>();
			//List<SelectListItem> cities = new List<SelectListItem>();
			//int counter = 1;
			//provinces.Add(new SelectListItem()
			//{
			//	Text = "انتخاب کنید",
			//	Value = ""
			//});
			//cities.Add(new SelectListItem()
			//{
			//	Text = "انتخاب کنید",
			//	Value = ""
			//});
			//foreach (var item in _provinceApplicationService.FindAll().Provinces)
			//{
			//	provinces.Add(new SelectListItem()
			//	{
			//		Text = item.Name,
			//		Value = item.Id.ToString()
			//	});
			//	if (item.Id == model.Member.ProvinceId)
			//	{
			//		provinces[counter].Selected = true;
			//		var cityCounter = 1;
			//		foreach (var city in _cityApplicationService.FindByProvinceId(item.Id).Items)
			//		{
			//			cities.Add(new SelectListItem()
			//			{
			//				Text = city.Text,
			//				Value = city.Id.ToString()
			//			});
			//			if (city.Id == model.Member.CityId)
			//			{
			//				cities[cityCounter].Selected = true;
			//			}
			//			cityCounter++;
			//		}
			//	}
			//	counter++;
			//}
			//if (string.IsNullOrWhiteSpace(model.Member.Gender))
			//{
			//	items[0].Selected = true;
			//}
			//else
			//{
			//	foreach (var item in items)
			//	{
			//		if (item.Value == model.Member.Gender)
			//		{
			//			item.Selected = true;
			//			break;
			//		}
			//	}
			//}
			//ViewBag.Genders = items;
			//ViewBag.Provinces = provinces;
			//ViewBag.Cities = cities;
			//return View(model);
			return View();
		}
		[HttpPost]
		[JwtAuthorize]
		public ActionResult Profile(ProfileAdditional model, HttpPostedFileBase file)
		{
			if (ModelState.IsValid)
			{
				var userId = long.Parse(Session["UserId"].ToString());
				var member = model.Member;
				var user = _usersApplicationService.Find(userId);
				user.Email = member.User.Email;
				_usersApplicationService.Save(user);
				_memberApplicationService.CreateMember(member);
			}
			else
			{

			}
			return RedirectToAction("Profile");
		}

		[JwtAuthorize]
		public ActionResult ImportantDates()
		{
			var userId = long.Parse(Session["UserId"].ToString());
			var member = _memberApplicationService.Find(userId);
			return View(member.ImportantDates);
		}

		[JwtAuthorize]
		[HttpPost]
		public ActionResult SaveImportantDate()
		{
			var dto = new MemberImportantDateDto()
			{
				MemberId = UserId

			};
			_memberImportantDateApplicationService.Save(dto);
			return RedirectToAction("ImportantDates");
		}
		public ActionResult Favorites()
		{
			return View();
		}
		[HttpPost]
		public ActionResult Favorites(MemberDto model)
		{
			return View();
		}
		public ActionResult Orders()
		{
			return View();
		}
		[JwtAuthorize]
		[HttpGet]
		public ActionResult Logout()
		{
			var token = Request.Cookies["UserSettings"]["Token"];
			if (Request.Cookies["UserSettings"] != null)
			{
				HttpCookie myCookie = new HttpCookie("UserSettings");
				myCookie.Expires = DateTime.Now.AddDays(-1d);
				Response.Cookies.Add(myCookie);
				Request.Cookies.Add(myCookie);
				Session["UserId"] = null;
				_tokenStoreApplication.InvalidateUserTokens(token);
				_tokenStoreApplication.DeleteExpiredTokens();
			}
			return Redirect("~");
		}
	}
}