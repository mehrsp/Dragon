using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using Rosentis.DomainModel.Products;

namespace Rosentis.Persistance.Mapping.Products
{
	public class ProductCatalogMap : EntityTypeConfiguration<ProductCatalog>
	{
		public ProductCatalogMap()
		{
			ToTable("ProductCatalogs", "prd").HasKey(x => x.Id);
			Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			HasRequired(x => x.Product).WithMany(x=>x.Catalogs).HasForeignKey(x => x.ProductId).WillCascadeOnDelete(false);
		}
	}
}
