using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using Rosentis.DomainModel.Products;

namespace Rosentis.Persistance.Mapping.Products
{
	public class ProductRelatedMap : EntityTypeConfiguration<ProductRelated>
	{
		public ProductRelatedMap()
		{
			ToTable("ProductRelateds", "prd").HasKey(x => x.Id);
			Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			HasRequired(x => x.Product).WithMany().HasForeignKey(x => x.ProductId).WillCascadeOnDelete(false);
		}
	}
}
