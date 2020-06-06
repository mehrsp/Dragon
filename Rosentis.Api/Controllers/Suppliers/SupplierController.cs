using Rosentis.DataContract.Base;
using Rosentis.DataContract.Base.Dtos;
using Rosentis.DataContract.Users;
using Rosentis.DataContract.Users.Dtos;
using Rosentis.ServiceContract.Suppliers;
using System.Web.Http;

namespace Rosentis.Api.Controllers.Suppliers
{
	[RoutePrefix("api/Suppliers")]
	public class SupplierController : ApiController
	{
		#region Propertises
		private ISupplierService _SupplierService;
		#endregion

		#region Ctors
		public SupplierController(ISupplierService SupplierService)
		{
			_SupplierService = SupplierService;
		}
		#endregion

		#region Methods
		[HttpPost]
		[Route("FindAll")]
		public SupplierDtos FindAll()
		{
			return _SupplierService.FindAll();
		}

		[HttpPost]
		[Route("FillDropBox")]
		public DropBoxDtos FillDropBox()
		{
			return _SupplierService.FillDropBox();
		}

		[HttpPost]
		[Route("Save")]
		public SupplierDto Save(SupplierDto dto)
		{
			return _SupplierService.Save(dto);
		}

		[HttpPost]
		[Route("Remove")]
		public DtoResponse Remove(SupplierDto dto)
		{
			return _SupplierService.Remove(dto);
		}

		[HttpPost]
		[Route("FindById")]
		public SupplierDto FindById(long id)
		{
			return _SupplierService.FindById(id);
		}
		#endregion
	}
}