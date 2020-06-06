using Rosentis.DomainModel.Blobs;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Rosentis.Persistance.Mapping.Blobs
{
    public class BlobDescriptionMap : EntityTypeConfiguration<BlobDescription>
    {
        public BlobDescriptionMap()
        {
			ToTable("BlobDescriptionMap", "gen").HasKey(x => x.Id);
			Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

			HasMany(x => x.Blobs);
		}
    }
}
