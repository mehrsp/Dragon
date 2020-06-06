using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

//https://www.dotnettips.info/post/837/ef-code-first-7

namespace Rosentis.Site.Controllers
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
                    var handler = new JwtSecurityTokenHandler();
                    var claimsIdentity = handler.ReadToken(AccessToken) as JwtSecurityToken;
                    var userId = claimsIdentity.Claims.First(x => x.Type == ClaimTypes.UserData).Value;
                    UserId = long.Parse(userId);
                }
            }

        }

        public long UserId { get; set; }

        public string AccessToken { get; set; }

        public bool IsAuthenticated { get; set; }
    }
}