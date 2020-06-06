using Rosentis.DomainModel.Brands;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Rosentis.Persistance.Mapping.Brands
{
    public class BrandMap : EntityTypeConfiguration<Brand>
    {
        public BrandMap()
        {
			ToTable("Brands", "prd").HasKey(x => x.Id);
			Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			HasRequired(x => x.Country).WithMany().HasForeignKey(x => x.CountryId).WillCascadeOnDelete(false);
		}
	}
}
