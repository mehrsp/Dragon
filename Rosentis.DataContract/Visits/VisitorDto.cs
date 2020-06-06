using Rosentis.DataContract.Base;
using System;

namespace Rosentis.DataContract.Visits
{
    public class VisitorDto: BaseDto
    {
		public string Ip {get; set;}
		public DateTime CreatedDate {get; set;}
		public string Status {get; set;}
		public Guid Id {get; set;}

    }
}
