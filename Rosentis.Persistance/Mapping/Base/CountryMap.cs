using Rosentis.DomainModel.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Rosentis.Persistance.Mapping.Base
{
    public class CountryMap : EntityTypeConfiguration<Country>
    {
        public CountryMap()
        {
			ToTable("Countries", "gen").HasKey(x => x.Id);
			Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
		}
    }
}
