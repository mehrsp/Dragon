using System;
using Rosentis.DataContract.AuthEntities;
using Rosentis.DataContract.Base;

namespace Rosentis.DataContract.Notification
{
    public class NotifierDto: BaseDto
    {
		public UserDto User {get; set;}
		public int Status {get; set;}
		public string Title {get; set;}
		public string Content {get; set;}
		public DateTime CreatedDate {get; set;}
		public DateTime? CheckedDate {get; set;}
		public bool IsChecked {get; set;}
		public Guid Id {get; set;}

    }
}
