using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using Rosentis.DomainModel.Users;

namespace Rosentis.Persistance.Mapping.Users
{
	public class RoleMap : EntityTypeConfiguration<Role>
	{
		public RoleMap()
		{
			ToTable("Roles", "sec").HasKey(x => x.Id);
			Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			
			HasMany(i => i.Permissions)
			 .WithMany()
			 .Map(m =>
			 {
				 m.ToTable("RolePermissions", "sec");
				 m.MapLeftKey("RoleId");
				 m.MapRightKey("PermissionId");
			 });
		}
	}
}
