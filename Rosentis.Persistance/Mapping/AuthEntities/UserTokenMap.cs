using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rosentis.DomainModel.AuthEntities;

namespace Rosentis.Persistance.Mapping.AuthEntities
{
    public class UserTokenMap : EntityTypeConfiguration<UserToken>
    {
        public UserTokenMap()
        {
			ToTable("UserTokens", "sec").HasKey(x => x.Id);
			Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
		}
    }
}
