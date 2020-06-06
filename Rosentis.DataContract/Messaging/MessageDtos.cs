using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rosentis.DataContract.Base;
namespace Rosentis.DataContract.Messaging
{
    public class MessageDtos: BaseDto
    {
        public List<MessageDto> Messages { get; set; }

        public MessageDtos()
        {
            Messages = new List<MessageDto>();
        }
    }
}
