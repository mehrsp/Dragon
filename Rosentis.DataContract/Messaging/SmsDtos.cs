using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rosentis.DataContract.Base;

namespace Rosentis.DataContract.Messaging
{
    public class SmsDtos: BaseDto
    {
        public List<SmsDto> Smss { get; set; }

        public SmsDtos()
        {
            Smss = new List<SmsDto>();
        }
    }
}
