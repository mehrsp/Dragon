using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using Rosentis.DomainModel.Users;

namespace Rosentis.Persistance.Mapping.Users
{
	public class MemberImportantDateMap : EntityTypeConfiguration<MemberImportantDate>
	{
		public MemberImportantDateMap()
		{
			ToTable("MemberImportantDates", "prj").HasKey(x => x.Id);
			Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
		}
	}
}
