using System;
using Rosentis.DataContract.Base;
using Rosentis.DataContract.AuthEntities;

namespace Rosentis.DataContract.Messaging
{
    public class SmsDto: BaseDto
    {
		public Int64? CreatedById {get; set;}
		public UserDto CreatedBy {get; set;}
		public DateTime CreatedDate {get; set;}
		public string To {get; set;}
		public string Text {get; set;}
		public Guid Id {get; set;}

    }
}
