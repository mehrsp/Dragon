using System.Data.Entity.ModelConfiguration;
using Rosentis.DomainModel.Shop;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rosentis.Persistance.Mapping.Shop
{
	public class ProductInvoiceTypeMap : EntityTypeConfiguration<ProductInvoiceType>
	{
		public ProductInvoiceTypeMap()
		{
			ToTable("ProductInvoiceTypes", "shp").HasKey(x => x.Id);
			Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
		}
	}
}
