using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using Rosentis.DomainModel.Products;

namespace Rosentis.Persistance.Mapping.Products
{
	public class TechnicalMap : EntityTypeConfiguration<Technical>
	{
		public TechnicalMap()
		{
			ToTable("Technicals", "prd").HasKey(x => x.Id);
			Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			HasOptional(x => x.Parent).WithMany(x => x.Children).HasForeignKey(x => x.ParentId).WillCascadeOnDelete(false);
		}
	}
}
