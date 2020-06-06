using System;
namespace Rosentis.DomainModel.Visits
{
    public class VisitorPage
    {
        protected VisitorPage()
        {

        }
		public Guid Id { get; set; }
		public string Ip {get; set;}
		public PageUrl PageUrl {get; set;}
		public DateTime CreatedDate {get; set;}
		public string Status {get; set;}
    }
}
