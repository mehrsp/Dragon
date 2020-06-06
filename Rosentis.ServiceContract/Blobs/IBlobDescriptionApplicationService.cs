using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rosentis.DataContract.Blobs;

namespace Rosentis.ServiceContract.Blobs
{
    public interface IBlobDescriptionApplicationService
    {
        BlobDescriptionDto Save(BlobDescriptionDto dto);
        bool Remove(BlobDescriptionDto dto);
        BlobDescriptionDtos FindAll();
        BlobDescriptionDto Find(long id);
    }
}
