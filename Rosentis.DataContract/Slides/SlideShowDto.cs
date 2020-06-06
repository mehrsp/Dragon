using Rosentis.DataContract.Base;

namespace Rosentis.DataContract.Slides
{
	public class SlideShowDto : BaseDto
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string Photo { get; set; }
		public string Link { get; set; }
		public int Priority { get; set; }

	}
}
