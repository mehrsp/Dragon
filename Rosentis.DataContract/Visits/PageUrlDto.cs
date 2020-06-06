using Rosentis.DataContract.Base;
using System;

namespace Rosentis.DataContract.Visits
{
    public class PageUrlDto: BaseDto
    {
		public string RawUrl {get; set;}
		public string PageTitle {get; set;}
		public DateTime CreatedDate {get; set;}
		public long Count {get; set;}
		public Guid Id {get; set;}

    }
}
