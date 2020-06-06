using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Rosentis.DataContract.AuthEntities;
using Rosentis.ServiceContract.AuthEntities;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using SecurityHelper = Rosentis.Api.Helpers.SecurityHelper;


namespace Rosentis.Api.JsonWebTokenConfig
{
    public class AppOAuthProvider : OAuthAuthorizationServerProvider
    {
        private readonly Func<IUsersApplicationService> _usersService;
        private readonly Func<ITokenStoreApplicationService> _tokenStoreService;
        private readonly IAppJwtConfiguration _configuration;

        /// <summary>
        /// Using Func here, creates transient Service's in a singleton AppOAuthProvider
        /// </summary>
        public AppOAuthProvider(
            Func<IUsersApplicationService> usersService,
            Func<ITokenStoreApplicationService> tokenStoreService,
            IAppJwtConfiguration configuration)
        {
            _usersService = usersService;
            _usersService.CheckArgumentNull(nameof(_usersService));

            _tokenStoreService = tokenStoreService;
            _tokenStoreService.CheckArgumentNull(nameof(_tokenStoreService));

            _configuration = configuration;
            _configuration.CheckArgumentNull(nameof(_configuration));
        }

        public override Task GrantRefreshToken(OAuthGrantRefreshTokenContext context)
        {
            // Resource owner password credentials does not provide a client ID.
            if (context.ClientId != null)
            {
                context.Rejected();
                return Task.FromResult(0);
            }

            // Change authentication ticket for refresh token requests
            var newIdentity = new ClaimsIdentity(context.Ticket.Identity);
            newIdentity.AddClaim(new Claim("newClaim", "refreshToken"));

            var newTicket = new AuthenticationTicket(newIdentity, context.Ticket.Properties);
            context.Validated(newTicket);

            var userId= int.Parse(context.Ticket.Identity.FindFirst(ClaimTypes.UserData).Value);
            _usersService().UpdateUserLastActivityDate(userId);

            return Task.FromResult(0);
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
            // how to get additional parameters
            var form = await context.Request.ReadFormAsync();
            var key2 = form["my-very-special-key1"];
            var data = await context.Request.ReadFormAsync();
            long phone = 0;
            int code = 0;
            UserDto user = null;
            if (!string.IsNullOrWhiteSpace(data.Get("code")))
            {
                phone = long.Parse(data.Get("phone"));
                code = int.Parse(data.Get("code"));
                user = _usersService().FindByPhoneCode(phone, code);
                user.UserName = phone.ToString();
            }
            else
            {
                user = _usersService().FindUser(context.UserName, context.Password);
            }
            if (user == null || !user.IsActive)
            {
                context.SetError("invalid_grant", "The user name or password is incorrect.");
                context.Rejected();
                return;
            }
            var props =
                new AuthenticationProperties(
                    new Dictionary<string, string>
                    {
                        { "dm:appid", user.Id.ToString() },
                    });
            var identity = setClaimsIdentity(context, user);
            List<string> permissions = new List<string>();
            List<string> roles = new List<string>();
            foreach (var item in user.Roles)
            {
                item.Permissions.ForEach(x =>
                {
                    permissions.Add(x.Name);
                });
                roles.Add(item.Name);
            }
            context.OwinContext.Set<string>("acl", Newtonsoft.Json.JsonConvert.SerializeObject(permissions));
            context.OwinContext.Set<string>("roles", Newtonsoft.Json.JsonConvert.SerializeObject(roles));
            var ticket = new AuthenticationTicket(identity, props);
            context.Validated(identity);
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            // Resource owner password credentials does not provide a client ID.
            if (context.ClientId == null)
            {
                context.Validated();
            }

            context.Validated();
            return Task.FromResult(0);
        }

        private ClaimsIdentity setClaimsIdentity(OAuthGrantResourceOwnerCredentialsContext context, UserDto user)
        {
            var identity = new ClaimsIdentity(authenticationType: "JWT");
            identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));

            // to invalidate the token
            identity.AddClaim(new Claim(ClaimTypes.SerialNumber, user.SerialNumber));

            // custom data
            identity.AddClaim(new Claim(ClaimTypes.UserData, user.Id.ToString()));

            var roles = user.Roles;
            foreach (var role in roles)
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, role.Name));
            }
            return identity;
        }
        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            context.Properties.Dictionary.Add(new KeyValuePair<string, string>("acl",context.OwinContext.Get<string>("acl")));
            context.Properties.Dictionary.Add(new KeyValuePair<string, string>("roles",context.OwinContext.Get<string>("roles")));
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }
            return Task.FromResult<object>(null);
        }
        public override Task TokenEndpointResponse(OAuthTokenEndpointResponseContext context)
        {
            _tokenStoreService().UpdateUserToken(
                userId: int.Parse(context.Identity.FindFirst(ClaimTypes.UserData).Value),
                accessTokenHash: SecurityHelper.GetSha256Hash(context.AccessToken)
            );

            return base.TokenEndpointResponse(context);
        }
    }
}