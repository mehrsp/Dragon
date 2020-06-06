using System;
namespace Rosentis.DomainModel.Visits
{
    public class Visitor
    {
        protected Visitor()
        {

        }
		public Guid Id { get; set; }
		public string Ip {get; set;}
		public DateTime CreatedDate {get; set;}
		public string Status {get; set;}

    }
}
