using System.Web.Mvc;

namespace Rosentis.Site.Controllers.Base
{
	public abstract class ApiController : Controller
	{
		protected override void OnActionExecuting(ActionExecutingContext ctx)
		{
			base.OnActionExecuting(ctx);
			ViewBag.IsAuthenticated = false;
			IsAuthenticated = false;
			if (ctx.HttpContext.Request.Cookies["UserSettings"] != null && !string.IsNullOrWhiteSpace(ctx.HttpContext.Request.Cookies["UserSettings"]["Token"]))
			{
				ViewBag.IsAuthenticated = true;
				IsAuthenticated = true;
				var responseCookie = Request.Cookies["UserSettings"];
				if (responseCookie != null)
				{
					AccessToken = responseCookie["Token"];
					//var handler = new JwtSecurityTokenHandler();
					//var claimsIdentity = handler.ReadToken(AccessToken) as JwtSecurityToken;
					//var userId = claimsIdentity.Claims.First(x => x.Type == ClaimTypes.UserData).Value;
					//UserId = long.Parse(userId);
				}
			}

		}

		public long UserId { get; set; }

		public string AccessToken { get; set; }

		public bool IsAuthenticated { get; set; }
	}
}