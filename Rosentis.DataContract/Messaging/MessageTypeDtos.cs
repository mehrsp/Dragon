using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rosentis.DataContract.Base;
namespace Rosentis.DataContract.Messaging
{
    public class MessageTypeDtos: BaseDto
    {
        public List<MessageTypeDto> MessageTypes { get; set; }

        public MessageTypeDtos()
        {
            MessageTypes = new List<MessageTypeDto>();
        }
    }
}
