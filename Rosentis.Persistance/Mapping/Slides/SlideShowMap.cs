using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using Rosentis.DomainModel.Slides;

namespace Rosentis.Persistance.Mapping.SlideShow
{
	public class SlideShowMap : EntityTypeConfiguration<Rosentis.DomainModel.Slides.SlideShow>
	{
		public SlideShowMap()
		{
			ToTable("SlideShows", "gen").HasKey(x => x.Id);
			Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			HasRequired(x => x.CreatedBy).WithMany().HasForeignKey(x => x.CreatedById).WillCascadeOnDelete(false);
		}
	}
}
