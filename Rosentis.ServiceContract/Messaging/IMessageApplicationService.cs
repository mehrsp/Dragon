using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rosentis.DataContract.Messaging;

namespace Rosentis.ServiceContract.Messaging
{
    public interface IMessageApplicationService
    {
        MessageDto Save(MessageDto dto);
        bool Remove(MessageDto dto);
        MessageDtos FindAll();
        MessageDto Find(Guid id);
    }
}
