using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rosentis.DataContract.Notification;

namespace Rosentis.ServiceContract.Notification
{
    public interface INotificationApplicationService
    {
        NotificationDto Save(NotificationDto dto);
        bool Remove(NotificationDto dto);
        IList<NotificationDto> FindAll();
        NotificationDto Find(Guid id);
    }
}
