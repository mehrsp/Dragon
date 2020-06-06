using Rosentis.DomainModel.Messaging;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Rosentis.Persistance.Mapping.Messaging
{
    public class MessageTypeMap : EntityTypeConfiguration<MessageType>
    {
        public MessageTypeMap()
        {
			ToTable("MessageTypeMap", "msg").HasKey(x => x.Id);
			Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
		}
    }
}
