using System;
using PersianDate;
using Rosentis.DataContract.Base;

namespace Rosentis.DataContract.Users
{
    public class MemberImportantDateDto: BaseDto
    {
		public MemberDto Member {get; set;}
		public string Title {get; set;}
		public string Description {get; set;}
		public DateTime Date {get; set;}
        public string DateShamsi => Date.ToFa();
		public DateTime CreatedDate {get; set;}
		public DateTime? ModifiedDate {get; set;}
		public long Id {get; set;}
        public long MemberId { get; set; }
    }
}
