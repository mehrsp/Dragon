using System;
using System.Collections.Generic;
using Rosentis.DataContract.Base;
namespace Rosentis.DataContract.Blobs
{
    public class BlobDtos: BaseDto
    {
        public List<BlobDto> Blobs { get; set; }

        public BlobDtos()
        {
            Blobs = new List<BlobDto>();
        }
    }
}
