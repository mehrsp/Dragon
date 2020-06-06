using System;
using System.ComponentModel.DataAnnotations;

namespace Rosentis.DomainModel.Users
{
	public class MemberImportantDate
	{
		public long Id { get; set; }
		public virtual Member Member { get; set; }
		public long MemberId { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public DateTime Date { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime? ModifiedDate { get; set; }

	}
}
