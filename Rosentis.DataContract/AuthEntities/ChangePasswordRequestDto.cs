using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rosentis.DataContract.Base;

namespace Rosentis.DataContract.AuthEntities
{
    public class ChangePasswordRequestDto:BaseDto
    {
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public long UserId { get; set; }
    }
}
