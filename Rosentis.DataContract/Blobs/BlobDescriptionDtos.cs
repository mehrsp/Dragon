using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rosentis.DataContract.Base;
namespace Rosentis.DataContract.Blobs
{
    public class BlobDescriptionDtos: BaseDto
    {
        public List<BlobDescriptionDto> BlobDescriptions { get; set; }

        public BlobDescriptionDtos()
        {
            BlobDescriptions = new List<BlobDescriptionDto>();
        }
    }
}
