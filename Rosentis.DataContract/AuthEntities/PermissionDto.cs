using System;
using System.Collections.Generic;
using Rosentis.DataContract.Base;

namespace Rosentis.DataContract.AuthEntities
{
    public class PermissionDto : BaseDto
    {
        public string Name { get; set; }
        public PermissionDto Parent { get; set; }
        public ICollection<PermissionDto> Children { get; set; }
        public long Id { get; set; }

        public PermissionDto()
        {
            Children = new List<PermissionDto>();
        }
    }
}
