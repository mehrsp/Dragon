using Rosentis.DomainModel.Exceptions;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Rosentis.Persistance.Mapping.ExceptionCategotys
{
    public class ExceptionCategotyMap : EntityTypeConfiguration<ExceptionCategory>
    {
        public ExceptionCategotyMap()
        {
			ToTable("ExceptionCategotys", "exp").HasKey(x => x.Id);
			Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
		}
    }
}
