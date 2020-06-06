using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using Rosentis.DomainModel.Users;

namespace Rosentis.Persistance.Mapping.Users
{
	public class SessionMap : EntityTypeConfiguration<Session>
	{
		public SessionMap()
		{
			ToTable("Sessions", "sec").HasKey(x => x.Id);
			Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			HasRequired(x => x.Member).WithMany().HasForeignKey(x => x.MemberId).WillCascadeOnDelete(false);
		}
	}
}
