using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rosentis.DataContract.Base;
namespace Rosentis.DataContract.Messaging
{
    public class EmailDtos: BaseDto
    {
        public List<EmailDto> Emails { get; set; }

        public EmailDtos()
        {
            Emails = new List<EmailDto>();
        }
    }
}
