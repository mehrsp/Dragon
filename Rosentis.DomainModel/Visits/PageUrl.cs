using System;
namespace Rosentis.DomainModel.Visits
{
    public class PageUrl
    {
        protected PageUrl()
        {

        }
		public Guid Id { get; set; }
		public string RawUrl {get; set;}
		public string PageTitle {get; set;}
		public DateTime CreatedDate {get; set;}
		public long Count {get; set;}
    }
}
