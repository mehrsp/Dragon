using System.Data.Entity.ModelConfiguration;
using Rosentis.DomainModel.Shop;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rosentis.Persistance.Mapping.Shop
{
	public class ProviderMap : EntityTypeConfiguration<Provider>
	{
		public ProviderMap()
		{
			ToTable("Providers", "shp").HasKey(x => x.Id);
			Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			HasRequired(x => x.Supplier).WithMany().HasForeignKey(x => x.SupplierId).WillCascadeOnDelete(false);

		}
	}
}
