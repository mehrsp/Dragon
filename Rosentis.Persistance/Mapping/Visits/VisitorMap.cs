using System.Data.Entity.ModelConfiguration;
using Rosentis.DomainModel.Visits;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rosentis.Persistance.Mapping.Visits
{
    public class VisitorMap : EntityTypeConfiguration<Visitor>
    {
        public VisitorMap()
        {
			ToTable("Visitors", "gen").HasKey(x => x.Id);
			Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
		}
    }
}
