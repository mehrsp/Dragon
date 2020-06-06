using System;
using System.ComponentModel.DataAnnotations.Schema;
using Rosentis.DomainModel.AuthEntities;

namespace Rosentis.DomainModel.Notification
{
    public class Notification 
    {
        public  Guid Id { get; set; }		
		public virtual User User {get;set;}
		public long UserId {get;set;}
		public string Content {get;set;}
		public DateTime CreatedDate {get;set;}
		public DateTime? CheckedDate {get;set;}
		public bool IsChecked {get;set;}

    }
}
