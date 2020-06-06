using System;
using Rosentis.DataContract.Slides;
using Rosentis.DataContract.Slides.Dtos;
using Rosentis.Persistance;
using Rosentis.ServiceContract.Slides;
using AutoMapper;
using System.Collections.Generic;
using Rosentis.DataContract.Base;
using Rosentis.ServiceImplementation.Slides.Mapper;
using Rosentis.Persistance.Facade;

namespace Rosentis.ServiceImplementation.SlideShow
{
	public class SlideShowApplicationService:  ISlideShowService
	{
		#region Properties
		private UnitOfWork _unitOfWork = new UnitOfWork();
		//private ISlideShowService _Slide;
		#endregion Properties
		#region Ctors
		public SlideShowApplicationService(RosentisContext context) 
		{
		}
		#endregion
        #region Methods
		public SlideShowDto Find(int id)
		{
			return Mapper.Map<SlideShowDto>(_unitOfWork.SlideShowRepository.GetFirst(x => x.Id == id));
		}

		public SlideShowDtos FindAll()
		{
			var test = _unitOfWork.SlideShowRepository.Get();
			return new SlideShowDtos
			{
				SlideShows = Mapper.Map<List<SlideShowDto>>(_unitOfWork.SlideShowRepository.Get())
			};
		}

		public DtoResponse Remove(SlideShowDto dto)
		{
			try
			{
				var slideShow = _unitOfWork.SlideShowRepository.GetFirst(x => x.Id == dto.Id);
				if (slideShow != null && slideShow.Id > 0)
				{
					_unitOfWork.SlideShowRepository.Delete(dto.Id);
					_unitOfWork.Save();
				}

				return new DtoResponse();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public SlideShowDto Save(SlideShowDto dto)
		{
			var slide = new Rosentis.DomainModel.Slides.SlideShow();
			slide = Mapper.Map<Rosentis.DomainModel.Slides.SlideShow>(dto);
			slide.CreatedDate = DateTime.Now;

			_unitOfWork.SlideShowRepository.Insert(slide);
			_unitOfWork.Save();

			dto.Id = slide.Id;

			return dto;
		}
		#endregion

	}
}
