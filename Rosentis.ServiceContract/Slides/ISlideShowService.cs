using Rosentis.DataContract.Base;
using Rosentis.DataContract.Slides;
using Rosentis.DataContract.Slides.Dtos;

namespace Rosentis.ServiceContract.Slides
{
	public interface ISlideShowService
	{
		SlideShowDto Save(SlideShowDto dto);
		DtoResponse Remove(SlideShowDto dto);
		SlideShowDtos FindAll();
		SlideShowDto Find(int id);
	}
}
