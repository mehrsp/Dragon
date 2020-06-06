using System.Data.Entity.ModelConfiguration;
using Rosentis.DomainModel.Shop;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rosentis.Persistance.Mapping.Shop
{
	public class InvoiceDetailsMap : EntityTypeConfiguration<InvoiceDetails>
	{
		public InvoiceDetailsMap()
		{
			ToTable("InvoiceDetails", "shp").HasKey(x => x.Id);
			Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			HasRequired(x => x.ProductInvoiceType).WithMany().HasForeignKey(x => x.ProductInvoiceTypeId).WillCascadeOnDelete(false);
		}
	}
}
