using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Rosentis.ServiceContract.AuthEntities;

namespace Rosentis.Site.Jwt
{
    public class JwtAuthorizeAttribute : AuthorizeAttribute
    {
        public string Permission { get; set; }
        /// <summary>
        /// Using Func here, creates transient IUsersService's
        /// </summary>
        public Func<IUsersApplicationService> UsersService { set; get; }


        /// <summary>
        /// Using Func here, creates transient ITokenStoreService's
        /// </summary>
        public Func<ITokenStoreApplicationService> TokenStoreService { set; get; }


        public override void OnAuthorization(AuthorizationContext actionContext)
        {
            if (HttpContext.Current.Request.Cookies["UserSettings"] == null && skipAuthorization(actionContext))
            {
                return;
            }

            var responseCookie = HttpContext.Current.Request.Cookies["UserSettings"];
            if (responseCookie != null)
            {
                var accessToken = responseCookie["Token"].ToString();
                if (string.IsNullOrWhiteSpace(accessToken) ||
                    accessToken.Equals("undefined", StringComparison.OrdinalIgnoreCase))
                {
                    // null token
                    this.HandleUnauthorizedRequest(actionContext);
                    return;
                }
                var handler = new JwtSecurityTokenHandler();
                var claimsIdentity = handler.ReadToken(accessToken) as JwtSecurityToken;
                if (claimsIdentity?.Claims == null || !claimsIdentity.Claims.Any())
                {
                    // this is not our issued token
                    this.HandleUnauthorizedRequest(actionContext);
                    return;
                }

                var userId = claimsIdentity.Claims.First(x => x.Type == ClaimTypes.UserData).Value;
                HttpContext.Current.Session["UserId"] = userId;
                //var serialNumberClaim = claimsIdentity.Claims.First(x => x.Type == ClaimTypes.SerialNumber);
                //if (serialNumberClaim == null)
                //{
                //    // this is not our issued token
                //    this.HandleUnauthorizedRequest(actionContext);
                //    return;
                //}
                //base.OnAuthorization(actionContext);
            }
            //    if (UsersService == null)
            //    {
            //        throw new NullReferenceException(
            //            $"{nameof(UsersService)} is null. Make sure ioc.Policies.SetAllProperties is configured and also IFilterProvider is replaced with SmWebApiFilterProvider.");
            //    }
            //    if (TokenStoreService == null)
            //    {
            //        throw new NullReferenceException(
            //            $"{nameof(TokenStoreService)} is null. Make sure ioc.Policies.SetAllProperties is configured and also IFilterProvider is replaced with SmWebApiFilterProvider.");
            //    }

            //    if (!TokenStoreService().IsValidToken(accessToken, int.Parse(userId)))
            //    {
            //        // this is not our issued token
            //        this.HandleUnauthorizedRequest(actionContext);
            //        return;
            //    }
            //    var user = UsersService().Find(long.Parse(userId));

            //    if (!string.IsNullOrEmpty(Roles))
            //    {
            //        var isValid = false;
            //        foreach (var role in Roles.Split(','))
            //        {
            //            if (user.Roles.FirstOrDefault(x => x.Name == role) != null || role == "Anonymous")
            //            {
            //                isValid = true;
            //            }
            //        }
            //        if (!isValid)
            //        {
            //            this.HandleUnauthorizedRequest(actionContext);
            //            return;
            //        }
            //    }
            //    if (!string.IsNullOrEmpty(Permission))
            //    {
            //        var isValid = false;
            //        foreach (var role in user.Roles)
            //        {
            //            if (role.Permissions.FirstOrDefault(x => x.Name == Permission) != null)
            //            {
            //                isValid = true;
            //                break;
            //            }
            //            else if (user.Permissions.FirstOrDefault(x => x.Name == Permission) != null)
            //            {
            //                isValid = true;
            //                break;
            //            }
            //        }
            //        if (!isValid)
            //        {
            //            this.HandleUnauthorizedRequest(actionContext);
            //        }
            //    }
            //}
            //else
            //{
            //        // null token
            //        this.HandleUnauthorizedRequest(actionContext);
            //        return;
            //}
            //base.OnAuthorization(actionContext);
        }

        private static bool skipAuthorization(AuthorizationContext actionContext)
        {
            return actionContext.ActionDescriptor
                .GetCustomAttributes(inherit: true)
                .OfType<AllowAnonymousAttribute>()
                //or any attr. you want
                .Any();
        }
    }

}