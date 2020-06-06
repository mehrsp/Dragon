using System.Data.Entity.ModelConfiguration;
using Rosentis.DomainModel.Shop;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace Rosentis.Persistance.Mapping.Shop
{
	public class CartItemMap : EntityTypeConfiguration<CartItem>
	{
		public CartItemMap()
		{
			ToTable("CartItems", "shp").HasKey(x => x.Id);
			Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			HasRequired(x => x.Product).WithMany().HasForeignKey(x => x.ProductId).WillCascadeOnDelete(false);
			HasRequired(x => x.Cart).WithMany(x=>x.CartItems).HasForeignKey(x => x.CartId).WillCascadeOnDelete(false);
		}
	}
}
