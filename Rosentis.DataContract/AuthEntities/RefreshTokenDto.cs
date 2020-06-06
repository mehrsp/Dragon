using System;
using Rosentis.DataContract.Base;

namespace Rosentis.DataContract.AuthEntities
{
    public class RefreshTokenDto: BaseDto
    {
		public string Subject {get; set;}
		public string ClientId {get; set;}
		public DateTime IssuedUtc {get; set;}
		public DateTime ExpiresUtc {get; set;}
		public string ProtectedTicket {get; set;}
		public string Id {get; set;}

    }
}
