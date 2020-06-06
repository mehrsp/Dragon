using Rosentis.DataContract.Base;
using System;

namespace Rosentis.DataContract.Visits
{
    public class VisitorPageDto: BaseDto
    {
		public string Ip {get; set;}
		public PageUrlDto PageUrl {get; set;}
		public DateTime CreatedDate {get; set;}
		public string Status {get; set;}
		public Guid Id {get; set;}

    }
}
