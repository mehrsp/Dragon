using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using Rosentis.DomainModel.Products;

namespace Rosentis.Persistance.Mapping.Products
{
	public class ProductCategoryMap : EntityTypeConfiguration<ProductCategory>
	{
		public ProductCategoryMap()
		{
			ToTable("ProductCategories", "prd").HasKey(x => x.Id);
			Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			HasRequired(x => x.CreatedBy).WithMany().HasForeignKey(x => x.CreatedById).WillCascadeOnDelete(false);
			HasOptional(x => x.Parent).WithMany(x => x.Children).HasForeignKey(x => x.ParentId).WillCascadeOnDelete(false);
		}
	}
}
