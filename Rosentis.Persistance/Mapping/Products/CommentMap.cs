using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using Rosentis.DomainModel.Products;

namespace Rosentis.Persistance.Mapping.Products
{
	public class CommentMap : EntityTypeConfiguration<Comment>
	{
		public CommentMap()
		{
			ToTable("Comments", "prd").HasKey(x => x.Id);
			Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			HasRequired(x => x.Product).WithMany(x=>x.Comments).HasForeignKey(x => x.ProductId).WillCascadeOnDelete(false);
			HasRequired(x => x.Member).WithMany().HasForeignKey(x => x.MemberId).WillCascadeOnDelete(false);
			HasOptional(x => x.Parent).WithMany(x =>x.Children).HasForeignKey(x => x.ParentId).WillCascadeOnDelete(false);

		}
	}
}
