using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Rosentis.DataContract.AuthEntities;
using Rosentis.ServiceContract.AuthEntities;
using Microsoft.Owin.Security.Infrastructure;
using SecurityHelper = Rosentis.Api.Helpers.SecurityHelper;

namespace Rosentis.Api.JsonWebTokenConfig
{
	/// <summary>
	/// With the refresh token the user does not need to login again and
	/// they can use refresh token to request a new authorization token.
	/// </summary>
	public class RefreshTokenProvider : IAuthenticationTokenProvider
	{
		private readonly IAppJwtConfiguration _configuration;
		private readonly Func<ITokenStoreApplicationService> _tokenStoreService;

		public RefreshTokenProvider(
			IAppJwtConfiguration configuration,
			Func<ITokenStoreApplicationService> tokenStoreService)
		{
			_configuration = configuration;
			_configuration.CheckArgumentNull(nameof(_configuration));

			_tokenStoreService = tokenStoreService;
			_tokenStoreService.CheckArgumentNull(nameof(_tokenStoreService));
		}

		public void Create(AuthenticationTokenCreateContext context)
		{
			CreateAsync(context).RunSynchronously();
		}

		public async Task CreateAsync(AuthenticationTokenCreateContext context)
		{
			var refreshTokenId = Guid.NewGuid().ToString("n");

			var now = DateTime.UtcNow;
			var ownerUserId = context.Ticket.Identity.FindFirst(ClaimTypes.UserData).Value;
			var token = new UserTokenDto()
			{
				OwnerUserId = int.Parse(ownerUserId),
				// Refresh token handles should be treated as secrets and should be stored hashed
				RefreshTokenIdHash = SecurityHelper.GetSha256Hash(refreshTokenId),
				Subject = context.Ticket.Identity.Name,
				RefreshTokenExpiresUtc = now.AddMinutes(Convert.ToDouble(_configuration.RefreshTokenExpirationMinutes)),
				AccessTokenExpirationDateTime = now.AddMinutes(Convert.ToDouble(_configuration.ExpirationMinutes))
			};
			context.Ticket.Properties.IssuedUtc = now;
			context.Ticket.Properties.ExpiresUtc = token.RefreshTokenExpiresUtc;

			token.RefreshToken = context.SerializeTicket();
			_tokenStoreService().CreateUserToken(token);
			_tokenStoreService().DeleteExpiredTokens();

			context.SetToken(refreshTokenId);
		}

		public void Receive(AuthenticationTokenReceiveContext context)
		{
			ReceiveAsync(context).RunSynchronously();
		}

		public async Task ReceiveAsync(AuthenticationTokenReceiveContext context)
		{
			var hashedTokenId = SecurityHelper.GetSha256Hash(context.Token);
			var refreshToken = _tokenStoreService().Find(hashedTokenId);
			if (refreshToken != null)
			{
				context.DeserializeTicket(refreshToken.RefreshToken);
				_tokenStoreService().DeleteToken(hashedTokenId);
			}
		}
	}
}