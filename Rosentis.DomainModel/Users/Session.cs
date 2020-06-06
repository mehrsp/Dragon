using Rosentis.DomainModel.Users;
using System;
namespace Rosentis.DomainModel.Users
{
    public class Session 
    {
		public Guid Id { get; set; }
		public string Imei {get; set;}
		public virtual Member Member {get; set;}
		public long MemberId {get; set;}
		public string Token {get; set;}
		public string DeviceType {get; set;}
		public string DeviceToken {get; set;}
		public DateTime? LastLoginDate {get; set;}
		public DateTime? LastOnlineDate {get; set;}

    }
}
