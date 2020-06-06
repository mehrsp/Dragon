namespace Rosentis.DomainModel.Blobs
{
    public class Blob
    {
		public long Id { get; set; }
		public string FileName { get; protected set; }
        public string FileStorageName { get; protected set; }
        public string Extension { get; protected set; }
        public long BlobDescriptionId { get; protected set; }
        public string FileType { get; protected set; }
        public virtual BlobDescription BlobDescription { get; protected set; }
    }
}
