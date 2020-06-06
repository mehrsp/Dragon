using Rosentis.DataContract.Base;
using Rosentis.DataContract.Base.Dtos;
using Rosentis.DataContract.Products;
using Rosentis.DataContract.Products.Dtos;
using Rosentis.ServiceContract.Products;
using System.Web;
using System.Web.Http;
using System;
using Rosentis.ServiceContract.AuthEntities;
using System.Security.Claims;
using Rosentis.DataContract.AuthEntities;

namespace Rosentis.Api.Controllers.Products
{
	[RoutePrefix("api/Technicals")]
	public class TechnicalsController : ApiController
	{
		private ITechnicalService _technicalService;
		public TechnicalsController(ITechnicalService technicalService)
		{
			_technicalService = technicalService;
		}

		[HttpPost]
		[Route("FindAll")]
		public TechnicalDtos FindAll()
		{
			return _technicalService.FindAll();
		}

		[HttpPost]
		[Route("FillDropBox")]
		public DropBoxDtos FillDropBox()
		{
			return _technicalService.FillDropBox();
		}


		[HttpPost]
		[Route("FillDropBoxByTechnicalId")]
		public DropBoxDtos FillDropBoxByTechnicalId(int id)
		{
			return _technicalService.FillDropBoxByTechnicalId(id);
		}

		[HttpPost]
		[Route("Save")]
		public TechnicalDto Save(TechnicalDto dto)
		{
			return _technicalService.Save(dto);
		}

		[HttpPost]
		[Route("Remove")]
		public DtoResponse Remove(TechnicalDto dto)
		{
			return _technicalService.Remove(dto);
		}

		[HttpPost]
		[Route("FindById")]
		public TechnicalDto FindById(int id)
		{
			return _technicalService.FindById(id);
		}

		[HttpPost]
		[Route("FindByTechnicalId")]
		public TechnicalDtos FindByTechnicalId(int id)
		{
			return _technicalService.FindByTechnicalId(id);
		}

	}
}