using Rosentis.DataContract.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Rosentis.DataContract.Users
{
    public class MemberImportantDateDtos: BaseDto
    {
        public List<MemberImportantDateDto> MemberImportantDates { get; set; }

        public MemberImportantDateDtos()
        {
            MemberImportantDates = new List<MemberImportantDateDto>();
        }
    }
}
