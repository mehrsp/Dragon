using Rosentis.DomainModel.Messaging;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Rosentis.Persistance.Mapping.Messaging
{
    public class MessageMap : EntityTypeConfiguration<Message>
    {
        public MessageMap()
        {
			ToTable("MessageMap", "msg").HasKey(x => x.Id);
			Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

			HasRequired(x => x.Scan).WithMany().HasForeignKey(x => x.ScanId).WillCascadeOnDelete(false);
			HasRequired(x => x.Sender).WithMany().HasForeignKey(x => x.userId).WillCascadeOnDelete(false);
			HasRequired(x => x.MessageType).WithMany().HasForeignKey(x => x.MessageTypeId).WillCascadeOnDelete(false);
		}
    }
}
