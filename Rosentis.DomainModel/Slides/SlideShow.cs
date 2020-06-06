using Rosentis.DomainModel.AuthEntities;
using System;
using System.ComponentModel.DataAnnotations;

namespace Rosentis.DomainModel.Slides
{
	public class SlideShow
	{
		[Key]
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string Photo { get; set; }
		public string Link { get; set; }
		public int Priority { get; set; }
		public long CreatedById { get; set; }
		public virtual User CreatedBy { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime? ModifiedDate { get; set; }
	}
}
