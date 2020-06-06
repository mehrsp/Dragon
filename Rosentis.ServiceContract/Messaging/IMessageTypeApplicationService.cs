using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rosentis.DataContract.Messaging;

namespace Rosentis.ServiceContract.Messaging
{
    public interface IMessageTypeApplicationService
    {
        MessageTypeDto Save(MessageTypeDto dto);
        bool Remove(MessageTypeDto dto);
        MessageTypeDtos FindAll();
        MessageTypeDto Find(int id);
    }
}
