using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rosentis.DataContract.Messaging;

namespace Rosentis.ServiceContract.Messaging
{
    public interface IEmailApplicationService
    {
        EmailDto Save(EmailDto dto);
        bool Remove(EmailDto dto);
        EmailDtos FindAll();
        EmailDto Find(Guid id);
        bool SendMessage(string to, string subject, string body);
    }
}
