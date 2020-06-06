using System;
using System.ComponentModel.DataAnnotations.Schema;
using Rosentis.DomainModel.AuthEntities;

namespace Rosentis.DomainModel.Messaging
{
    public class Email
	{
        public Guid Id { get; set; }

        protected Email()
        {

        }
		public Int64? CreatedById {get;set;}
		public virtual User CreatedBy {get;set;}
		public DateTime CreatedDate {get;set;}
    }
}
