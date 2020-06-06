using System.Data.Entity.ModelConfiguration;
using Rosentis.DomainModel.Visits;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rosentis.Persistance.Mapping.Visits
{
    public class PageUrlMap : EntityTypeConfiguration<PageUrl>
    {
        public PageUrlMap()
        {
			ToTable("PageUrls", "gen").HasKey(x => x.Id);
			Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
		}
    }
}
