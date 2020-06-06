using Rosentis.DomainModel.Blobs;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Rosentis.Persistance.Mapping.Blobs
{
    public class BlobMap : EntityTypeConfiguration<Blob>
    {
        public BlobMap()
        {
			ToTable("BlobMap", "gen").HasKey(x => x.Id);
			Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

			HasRequired(x => x.BlobDescription).WithMany(x=>x.Blobs).HasForeignKey(x=>x.BlobDescriptionId).WillCascadeOnDelete(false);
		}
    }
}
