using System;

namespace Rosentis.DomainModel.AuthEntities
{
	public class UserToken 
	{
		public UserToken()
		{

		}
		public UserToken(long ownerUserId, string accessTokenHash, DateTime accessTokenExpirationDateTime, string refreshTokenIdHash, string subject, DateTime refreshTokenExpiresUtc, string refreshToken, Guid id)
		{
			OwnerUserId = ownerUserId;
			AccessTokenHash = accessTokenHash;
			AccessTokenExpirationDateTime = accessTokenExpirationDateTime;
			RefreshTokenIdHash = refreshTokenIdHash;
			Subject = subject;
			RefreshTokenExpiresUtc = refreshTokenExpiresUtc;
			RefreshToken = refreshToken;
			Id = id;
		}
		public Guid Id { get; set; }
		public long OwnerUserId { get; set; }
		public string AccessTokenHash { get; set; }
		public DateTime AccessTokenExpirationDateTime { get; set; }
		public string RefreshTokenIdHash { get; set; }
		public string Subject { get; set; }
		public DateTime RefreshTokenExpiresUtc { get; set; }
		public string RefreshToken { get; set; }
		
	}
}
