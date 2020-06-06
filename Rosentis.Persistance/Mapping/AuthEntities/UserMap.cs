using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rosentis.DomainModel.AuthEntities;

namespace Rosentis.Persistance.Mapping.AuthEntities
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
			ToTable("Users", "sec").HasKey(x => x.Id);
			Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			Property(x => x.Phone);
            HasMany(p => p.Roles).WithMany().Map(p =>
            {
                p.ToTable("UserRoles", "sec");
                p.MapLeftKey("UserId");
                p.MapRightKey("RoleId");
            });
           HasMany(i => i.Permissions)
                .WithMany()
                .Map(m =>
                {
                    m.ToTable("UserPermissions", "sec");
                    m.MapLeftKey("UserId");
                    m.MapRightKey("PermissionId");
                });
        }
    }
}
