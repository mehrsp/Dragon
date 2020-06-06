using Rosentis.DomainModel.AuthEntities;
using Rosentis.DataContract.Slides;
using Rosentis.DistributedServices;
using Rosentis.DomainModel.Slides.NullObjects;
using Rosentis.DataContract.AuthEntities;

namespace Rosentis.ServiceImplementation.Slides.Mapper
{
	public class SlideShowMapper : IEntityMapper<Rosentis.DomainModel.Slides.SlideShow, SlideShowDto>
	{
		private IEntityMapper<User, UserDto> _userMapper;

		public SlideShowMapper(IEntityMapper<User, UserDto> userMapper)
		{
			_userMapper = userMapper;
		}
		public Rosentis.DomainModel.Slides.SlideShow CreateFrom(SlideShowDto domainDto)
		{
			if (domainDto == null)
				return new NullSlideShow();
			return new Rosentis.DomainModel.Slides.SlideShow();

		}

		public SlideShowDto MapTo(Rosentis.DomainModel.Slides.SlideShow domain)
		{
			SlideShowDto domainDto = new SlideShowDto();
			if (domain != null)
			{
				domainDto.Title = domain.Title;
				domainDto.Description = domain.Description;
				domainDto.Photo = domain.Photo;
				domainDto.Link = domain.Link;
				domainDto.Priority = domain.Priority;
				domainDto.Id = domain.Id;

			}

			return domainDto;
		}
	}

}