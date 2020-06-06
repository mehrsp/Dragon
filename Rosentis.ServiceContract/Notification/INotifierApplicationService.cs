using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rosentis.DataContract.Notification;

namespace Rosentis.ServiceContract.Notification
{
    public interface INotifierApplicationService
    {
        NotifierDto Save(NotifierDto dto);
        bool Remove(NotifierDto dto);
        IList<NotifierDto> FindAll();
        NotifierDto Find(Guid id);
    }
}
