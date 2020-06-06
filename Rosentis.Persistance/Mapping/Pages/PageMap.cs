using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using Rosentis.DomainModel.Pages;

namespace Rosentis.Persistance.Mapping.Pages
{
	public class PageMap : EntityTypeConfiguration<Page>
	{
		public PageMap()
		{
			ToTable("Pages", "gen").HasKey(x => x.Id);
			Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
		}
	}
}
