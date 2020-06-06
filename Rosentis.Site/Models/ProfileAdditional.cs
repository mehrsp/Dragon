using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Rosentis.DataContract.Users;

namespace Rosentis.Site.Models
{
    public class ProfileAdditional
    {
        public MemberDto Member { get; set; }

        public ProfileAdditional()
        {
            Member = new MemberDto();
        }
    }
}