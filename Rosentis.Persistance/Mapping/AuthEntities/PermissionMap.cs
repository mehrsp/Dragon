using System.Data.Entity.ModelConfiguration;
using Rosentis.DomainModel.AuthEntities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rosentis.Persistance.Mapping.AuthEntities
{
    public class PermissionMap : EntityTypeConfiguration<Permission>
    {
        public PermissionMap()
        {
			ToTable("Permissions", "sec").HasKey(x => x.Id).HasMany(x => x.Children);
			Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			
		}
    }
}
