using Rosentis.DataContract.Base;
using System.Collections.Generic;

namespace Rosentis.DataContract.Slides.Dtos
{
	public class SlideShowDtos: BaseDto
	{
		public List<SlideShowDto> SlideShows { get; set; }

		public SlideShowDtos()
		{
			SlideShows = new List<SlideShowDto>();
		}
	}
}
