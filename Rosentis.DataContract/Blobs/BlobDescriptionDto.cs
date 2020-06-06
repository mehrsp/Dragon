using System.Collections.Generic;
using Rosentis.DataContract.Base;

namespace Rosentis.DataContract.Blobs
{
    public class BlobDescriptionDto: BaseDto
    {
		public IList<BlobDto> Blobs {get; set;}
		public long Id {get; set;}

        public BlobDescriptionDto()
        {
            Blobs = new List<BlobDto>();
        }

    }
}
