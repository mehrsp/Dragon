using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rosentis.DataContract.Base;
using Rosentis.DataContract.Messaging;

namespace Rosentis.ServiceContract.Messaging
{
    public interface ISmsApplicationService
    {
        SmsDto Save(SmsDto dto);
        bool Remove(SmsDto dto);
        SmsDtos FindAll();
        SmsDto Find(Guid id);
        DtoResponse Send(long mobile,string message);
    }
}
