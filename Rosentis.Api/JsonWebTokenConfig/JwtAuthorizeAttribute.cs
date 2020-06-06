﻿using System;
using System.Linq;
using System.Security.Claims;
using System.Web.Http;
using System.Web.Http.Controllers;
using Rosentis.ServiceContract.AuthEntities;

namespace Rosentis.Api.JsonWebTokenConfig
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


        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (skipAuthorization(actionContext))
            {
                return;
            }

            var accessToken = actionContext.Request.Headers.Authorization.Parameter;
            if (string.IsNullOrWhiteSpace(accessToken) ||
                accessToken.Equals("undefined", StringComparison.OrdinalIgnoreCase))
            {
                // null token
                this.HandleUnauthorizedRequest(actionContext);
                return;
            }
            var claimsIdentity = actionContext.RequestContext.Principal.Identity as ClaimsIdentity;
            if (claimsIdentity?.Claims == null || !claimsIdentity.Claims.Any())
            {
                // this is not our issued token
                this.HandleUnauthorizedRequest(actionContext);
                return;
            }

            var userId = claimsIdentity.FindFirst(ClaimTypes.UserData).Value;

            var serialNumberClaim = claimsIdentity.FindFirst(ClaimTypes.SerialNumber);
            if (serialNumberClaim == null)
            {
                // this is not our issued token
                this.HandleUnauthorizedRequest(actionContext);
                return;
            }

            if (UsersService == null)
            {
                throw new NullReferenceException($"{nameof(UsersService)} is null. Make sure ioc.Policies.SetAllProperties is configured and also IFilterProvider is replaced with SmWebApiFilterProvider.");
            }

            //var serialNumber = UsersService().GetSerialNumber(int.Parse(userId));
            //if (serialNumber != serialNumberClaim.Value)
            //{
            //    // user has changed his/her password/roles/stat/IsActive
            //    this.HandleUnauthorizedRequest(actionContext);
            //    return;
            //}


            if (TokenStoreService == null)
            {
                throw new NullReferenceException($"{nameof(TokenStoreService)} is null. Make sure ioc.Policies.SetAllProperties is configured and also IFilterProvider is replaced with SmWebApiFilterProvider.");
            }

            if (!TokenStoreService().IsValidToken(accessToken, int.Parse(userId)))
            {
                // this is not our issued token
                this.HandleUnauthorizedRequest(actionContext);
                return;
            }
            var user = UsersService().Find(long.Parse(userId));

            if (!string.IsNullOrEmpty(Roles))
            {
                var isValid = false;
                foreach (var role in Roles.Split(','))
                {
                    if (user.Roles.FirstOrDefault(x => x.Name == role) != null || role=="Anonymous")
                    {
                        isValid = true;
                    }
                }
                if (!isValid)
                {
                    this.HandleUnauthorizedRequest(actionContext);
                    return;
                }
            }
            if (!string.IsNullOrEmpty(Permission))
            {
                var isValid = false;
                foreach (var role in user.Roles)
                {
                    if (role.Permissions.FirstOrDefault(x => x.Name == Permission) != null)
                    {
                        isValid = true;
                        break;
                    }
                    else if (user.Permissions.FirstOrDefault(x => x.Name == Permission) != null)
                    {
                        isValid = true;
                        break;
                    }
                }
                if (!isValid)
                {
                    this.HandleUnauthorizedRequest(actionContext);
                }
            }
            base.OnAuthorization(actionContext);
        }

        private static bool skipAuthorization(HttpActionContext actionContext)
        {
            return actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any()
                   || actionContext.ControllerContext.ControllerDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any();
        }
    }
}