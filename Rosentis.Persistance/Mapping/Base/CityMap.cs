using Rosentis.DomainModel.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Rosentis.Persistance.Mapping.Base
{
    public class CityMap : EntityTypeConfiguration<City>
    {
        public CityMap()
        {
			ToTable("Cities", "gen").HasKey(x => x.Id);
			Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

			HasRequired(x => x.Province).WithMany(x=>x.Cities).HasForeignKey(x => x.ProvinceId).WillCascadeOnDelete(false);
		}
    }
}
