using System.Data.Entity.ModelConfiguration;
using Rosentis.DomainModel.Shop;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rosentis.Persistance.Mapping.Shop
{
	public class PurchaseMap : EntityTypeConfiguration<Purchase>
	{
		public PurchaseMap()
		{
			ToTable("Purchases", "shp").HasKey(x => x.Id);
			Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			HasRequired(x => x.Provider).WithMany(x=>x.Purchases).HasForeignKey(x => x.ProviderId).WillCascadeOnDelete(false);
			HasRequired(x => x.PurchaseType).WithMany(x => x.Purchases).HasForeignKey(x => x.PurchaseTypeId).WillCascadeOnDelete(false);
			HasRequired(x => x.Invoice).WithMany().HasForeignKey(x => x.InvoiceId).WillCascadeOnDelete(false);
		}
	}
}
