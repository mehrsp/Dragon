using System.Data.Entity.ModelConfiguration;
using Rosentis.DomainModel.Shop;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rosentis.Persistance.Mapping.Shop
{
	public class PurchaseTypeMap : EntityTypeConfiguration<PurchaseType>
	{
		public PurchaseTypeMap()
		{
			ToTable("PurchaseTypes", "shp").HasKey(x => x.Id);
			Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
		}
	}
}
