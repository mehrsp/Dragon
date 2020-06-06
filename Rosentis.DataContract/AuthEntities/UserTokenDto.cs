using System;
using Rosentis.DataContract.Base;

namespace Rosentis.DataContract.AuthEntities
{
    public class UserTokenDto: BaseDto
    {
		public long OwnerUserId {get; set;}
		public string AccessTokenHash {get; set;}
		public DateTime AccessTokenExpirationDateTime {get; set;}
		public string RefreshTokenIdHash {get; set;}
		public string Subject {get; set;}
		public DateTime RefreshTokenExpiresUtc {get; set;}
		public string RefreshToken {get; set;}
		public Guid Id {get; set;}

    }
}
