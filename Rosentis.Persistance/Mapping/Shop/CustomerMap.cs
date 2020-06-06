using System.Data.Entity.ModelConfiguration;
using Rosentis.DomainModel.Shop;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rosentis.Persistance.Mapping.Shop
{
	public class CustomerMap : EntityTypeConfiguration<Customer>
	{
		public CustomerMap()
		{
			ToTable("Customers", "shp");
			HasRequired(x => x.User).WithMany().HasForeignKey(x => x.UserId);
			HasOptional(x => x.Province).WithMany().HasForeignKey(x => x.ProvinceId).WillCascadeOnDelete(false);
			HasOptional(x => x.Province).WithMany().HasForeignKey(x => x.ProvinceId).WillCascadeOnDelete(false);
		}
	}
}
