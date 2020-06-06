using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using Rosentis.DomainModel.Products;

namespace Rosentis.Persistance.Mapping.Products
{
	public class ProductCategoryTechnicalMap : EntityTypeConfiguration<ProductCategoryTechnical>
	{
		public ProductCategoryTechnicalMap()
		{
			ToTable("ProductCategoryTechnicals", "prd").HasKey(x => x.Id);
			Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			HasRequired(x => x.ProductCategory).WithMany(x=>x.ProductCategoryTechnicals).HasForeignKey(x => x.ProductCategoryId).WillCascadeOnDelete(false);
			HasOptional(x => x.Technical).WithMany().HasForeignKey(x => x.TechnicalId).WillCascadeOnDelete(false);
			HasOptional(x => x.Brand).WithMany().HasForeignKey(x => x.BrandId).WillCascadeOnDelete(false);
		}
	}
}
