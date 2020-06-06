using Rosentis.DomainModel.Messaging;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Rosentis.Persistance.Mapping.Messaging
{
    public class SmsMap : EntityTypeConfiguration<Sms>
    {
        public SmsMap()
        {
			ToTable("SmsMap", "msg").HasKey(x => x.Id);
			Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

			HasRequired(x => x.CreatedBy).WithMany().HasForeignKey(x=>x.CreatedById).WillCascadeOnDelete(false); 
		}
    }
}
