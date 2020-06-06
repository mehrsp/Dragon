using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using Rosentis.DomainModel.Tags;

namespace Rosentis.Persistance.Mapping.Tags
{
	public class TagMap : EntityTypeConfiguration<Tag>
	{
		public TagMap()
		{
			ToTable("Tags", "prd").HasKey(x => x.Id);
			Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			HasRequired(x => x.Type).WithMany().HasForeignKey(x => x.TypeId).WillCascadeOnDelete(false);
		}
	}
}
