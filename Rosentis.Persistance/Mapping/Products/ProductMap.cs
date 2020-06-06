using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using Rosentis.DomainModel.Products;

namespace Rosentis.Persistance.Mapping.Products
{
	public class ProductMap : EntityTypeConfiguration<Product>
	{
		public ProductMap()
		{
			ToTable("Products", "prd").HasKey(x => x.Id);
			Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

			HasOptional(x => x.Brand).WithMany().HasForeignKey(x => x.BrandId);
			HasOptional(x => x.Supplier).WithMany().HasForeignKey(x => x.SupplierId);
			HasRequired(x => x.CreatedBy).WithMany().HasForeignKey(x => x.CreatedById).WillCascadeOnDelete(false);
			HasOptional(x => x.ProductCategory).WithMany(x=>x.Products).HasForeignKey(x => x.ProductCategoryId).WillCascadeOnDelete(false);
			HasOptional(x => x.Parent).WithMany(x=>x.Children).HasForeignKey(x => x.ParentId).WillCascadeOnDelete(false);
		}
	}
}
