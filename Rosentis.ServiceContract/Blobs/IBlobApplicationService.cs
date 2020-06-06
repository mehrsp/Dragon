using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rosentis.DataContract.Blobs;

namespace Rosentis.ServiceContract.Blobs
{
    public interface IBlobApplicationService
    {
        BlobDto Save(BlobDto dto);
        bool Remove(BlobDto dto);
        BlobDtos FindAll();
        BlobDto Find(long id);
    }
}
