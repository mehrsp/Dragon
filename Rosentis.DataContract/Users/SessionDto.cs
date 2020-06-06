using System;
using Rosentis.DataContract.Users;
using Rosentis.DataContract.Base;

namespace Rosentis.DataContract.Users
{
    public class SessionDto: BaseDto
    {
		public string Imei {get; set;}
		public MemberDto Member {get; set;}
		public long MemberId {get; set;}
		public string Token {get; set;}
		public string DeviceType {get; set;}
		public string DeviceToken {get; set;}
		public DateTime? LastLoginDate {get; set;}
		public DateTime? LastOnlineDate {get; set;}
		public Guid Id {get; set;}

    }
}
