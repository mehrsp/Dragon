using System.Data.Entity.ModelConfiguration;
using Rosentis.DomainModel.Shop;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rosentis.Persistance.Mapping.Shop
{
	public class InvoiceMap : EntityTypeConfiguration<Invoice>
	{
		public InvoiceMap()
		{
			ToTable("Invoices", "shp").HasKey(x => x.Id);
			Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			HasRequired(x => x.User).WithMany().HasForeignKey(x => x.UserId).WillCascadeOnDelete(false);
		}
	}
}
