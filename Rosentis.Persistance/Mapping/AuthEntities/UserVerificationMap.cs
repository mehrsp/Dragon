using System.Data.Entity.ModelConfiguration;
using Rosentis.DomainModel.AuthEntities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rosentis.Persistance.Mapping.AuthEntities
{
    public class UserVerificationMap : EntityTypeConfiguration<UserVerification>
    {
        public UserVerificationMap()
        {
			ToTable("UserVerifications", "sec").HasKey(x => x.Id);
			Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
		}
    }
}
