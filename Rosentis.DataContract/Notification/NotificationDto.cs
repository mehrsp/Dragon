using System;
using Rosentis.DataContract.AuthEntities;
using Rosentis.DataContract.Base;

namespace Rosentis.DataContract.Notification
{
    public class NotificationDto: BaseDto
    {
        public UserDto User { get; set; }
        public long UserId { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? CheckedDate { get; set; }
        public bool IsChecked { get; set; }
        public Guid Id { get; set; }
    }
}
