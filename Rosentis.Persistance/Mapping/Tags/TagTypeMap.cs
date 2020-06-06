using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using Rosentis.DomainModel.Slides;
using Rosentis.DomainModel.Tags;

namespace Rosentis.Persistance.Mapping.Tags
{
	public class TagTypeMap : EntityTypeConfiguration<TagType>
	{
		public TagTypeMap()
		{
			ToTable("TagTypes", "prd").HasKey(x => x.Id);
			Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
		}
	}
}
