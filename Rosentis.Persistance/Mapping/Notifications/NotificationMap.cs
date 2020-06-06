using Rosentis.DomainModel.Notification;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Rosentis.Persistance.Mapping.Notifications
{
    public class NotificationMap : EntityTypeConfiguration<Notification>
    {
        public NotificationMap()
        {
			ToTable("Notifications", "gen").HasKey(x => x.Id);
			Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

			HasRequired(x => x.User).WithMany().HasForeignKey(x => x.UserId).WillCascadeOnDelete(false);
		}
    }
}
