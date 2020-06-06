using System;
using Rosentis.DataContract.Base;
using Rosentis.DataContract.AuthEntities;

namespace Rosentis.DataContract.Messaging
{
    public class EmailDto: BaseDto
    {
		public Int64? CreatedById {get; set;}
		public UserDto CreatedBy {get; set;}
		public DateTime CreatedDate {get; set;}
		public Guid Id {get; set;}

    }
}
