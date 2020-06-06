using Rosentis.DataContract.Base;

namespace Rosentis.DataContract.Blobs
{
    public class BlobDto: BaseDto
    {
		public string FileName {get; set;}
		public string FileStorageName {get; set;}
		public string Extension {get; set;}
		public int BlobDescriptionId {get; set;}
		public string FileType {get; set;}
		public BlobDescriptionDto BlobDescription {get; set;}
		public long Id {get; set;}

    }
}
