using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using Rosentis.DomainModel.Products;

namespace Rosentis.Persistance.Mapping.Products
{
	public class ProductTechinicalMap : EntityTypeConfiguration<ProductTechnical>
	{
		public ProductTechinicalMap()
		{
			ToTable("ProductTechinicals", "prd").HasKey(x => x.Id);
			Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			HasRequired(x => x.Product).WithMany(x=>x.Technicals).HasForeignKey(x => x.ProductId).WillCascadeOnDelete(false);
			HasOptional(x => x.Technical).WithMany().HasForeignKey(x => x.TechnicalId).WillCascadeOnDelete(false);
		}
	}
}
