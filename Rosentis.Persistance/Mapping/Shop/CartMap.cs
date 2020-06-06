using System.Data.Entity.ModelConfiguration;
using Rosentis.DomainModel.Shop;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rosentis.Persistance.Mapping.Shop
{
	public class CartMap : EntityTypeConfiguration<Cart>
	{
		public CartMap()
		{
			ToTable("Carts", "shp").HasKey(x => x.Id);
			Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			HasOptional(x => x.User).WithMany().HasForeignKey(x => x.UserId).WillCascadeOnDelete(false);
		}
	}
}
