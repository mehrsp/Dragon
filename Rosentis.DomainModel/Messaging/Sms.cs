using System;
using System.ComponentModel.DataAnnotations.Schema;
using Rosentis.DomainModel.AuthEntities;

namespace Rosentis.DomainModel.Messaging
{
    public class Sms
    {
		public Guid Id { get; set; }
		public Int64? CreatedById {get;set;}
		public virtual User CreatedBy {get;set;}
		public DateTime CreatedDate {get;set;}
		public string To {get;set;}
		public string Text {get;set;}
    }
}
