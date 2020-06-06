using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using Rosentis.DomainModel.Users;

namespace Rosentis.Persistance.Mapping.Users
{
	public class MemberMap : EntityTypeConfiguration<Member>
	{
		public MemberMap()
		{
			ToTable("Members", "prj").HasKey(x => x.Id);
			Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			HasRequired(x => x.Province).WithMany().HasForeignKey(x => x.ProvinceId).WillCascadeOnDelete(false);
			HasRequired(x => x.City).WithMany().HasForeignKey(x => x.CityId).WillCascadeOnDelete(false);

			HasMany(i => i.Likes)
			  .WithMany()
			  .Map(m =>
			  {
				  m.ToTable("MemberProductsLike", "prj");
				  m.MapLeftKey("ProductId");
				  m.MapRightKey("MemberId");
			  });
			HasMany(i => i.Favorites)
				.WithMany()
				.Map(m =>
				{
					m.ToTable("MemberProductsFavorite", "prj");
					m.MapLeftKey("ProductId");
					m.MapRightKey("MemberId");
				});
		}
	}
}
