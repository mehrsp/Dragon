using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rosentis.DataContract.Base;
namespace Rosentis.DataContract.AuthEntities
{
    public class PermissionDtos: BaseDto
    {
        public List<PermissionDto> Permissions { get; set; }

        public PermissionDtos()
        {
            Permissions = new List<PermissionDto>();
        }
    }
}
