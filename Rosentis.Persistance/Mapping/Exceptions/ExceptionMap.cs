using Rosentis.DomainModel.Exceptions;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Rosentis.Persistance.Mapping.Exceptions
{
    public class ExceptionMap : EntityTypeConfiguration<Exception>
    {
        public ExceptionMap()
        {
			ToTable("Exceptions", "exp").HasKey(x => x.Id);
			Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

			HasRequired(x => x.Category).WithMany().HasForeignKey(x => x.CategoryId).WillCascadeOnDelete(false);
		}
    }
}
