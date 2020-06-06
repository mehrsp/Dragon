using Rosentis.DataContract.Slides;
using Rosentis.DistributedServices;
using Rosentis.ServiceContract.Slides;
using Rosentis.ServiceImplementation.Slides.Mapper;
using Rosentis.DomainModel.Slides;

namespace Rosentis.ServiceImplementation.SlideShow.Registry
{
		public class SlideShowRegistry : StructureMap.Registry
		{
	
			public SlideShowRegistry()
			{
				this.For<ISlideShowService>().Use<SlideShowApplicationService>();
				this.For<IEntityMapper<Rosentis.DomainModel.Slides.SlideShow, SlideShowDto>>().Use<SlideShowMapper>();

			}
		}
}
