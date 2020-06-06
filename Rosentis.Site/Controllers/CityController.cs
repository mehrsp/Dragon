using Rosentis.ServiceContract.Info.Address;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Rosentis.Site.Controllers
{
    public class CityController : Controller
    {
		private ICityService _cityApplicationService;

		public CityController(ICityService cityApplicationService)
		{
			_cityApplicationService = cityApplicationService;
		}
		// GET: City
		[HttpPost]
		public JsonResult GetCities(int id)
		{
			List<SelectListItem> cities = new List<SelectListItem>();
			cities.Add(new SelectListItem()
			{
				Text = "انتخاب کنید",
				Value = ""
			});
			var cityCounter = 1;
			foreach (var city in _cityApplicationService.FindByProvinceId(id).Items)
			{
				cities.Add(new SelectListItem()
				{
					Text = city.Text,
					Value = city.Id.ToString()
				});
				cityCounter++;
			}
			return Json(cities, JsonRequestBehavior.AllowGet);
		}
	}
}