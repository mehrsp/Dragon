using System.Data.Entity.ModelConfiguration;
using Rosentis.DomainModel.Visits;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rosentis.Persistance.Mapping.Visits
{
    public class VisitorPageMap : EntityTypeConfiguration<VisitorPage>
    {
        public VisitorPageMap()
        {
			ToTable("VisitorPages", "gen").HasKey(x => x.Id);
			Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
		}
    }
}
