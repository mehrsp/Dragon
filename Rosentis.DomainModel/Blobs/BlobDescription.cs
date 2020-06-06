using System.Collections.Generic;

namespace Rosentis.DomainModel.Blobs
{
    public class BlobDescription
    {
        public BlobDescription()
        {
            this.Blobs = new List<Blob>();
        }

        public BlobDescription(IList<Blob> blobs, long id):this()
        {
            Id = id;
            if (blobs != null)
            {
                this.Blobs = blobs;
            }
        }
		public long Id { get; set; }
        public  virtual ICollection<Blob> Blobs { get; set; }
        //public void SetNewId()
        //{
        //    this.Id = Guid.NewGuid();

        //}
    }
}
