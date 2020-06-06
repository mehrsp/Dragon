using Rosentis.DataContract.Base;
using Rosentis.DataContract.Base.Dtos;
using Rosentis.DataContract.Users;
using Rosentis.DataContract.Users.Dtos;

namespace Rosentis.ServiceContract.Suppliers
{
	public interface ISupplierService
	{
		SupplierDto Save(SupplierDto dto);
		DtoResponse Remove(SupplierDto dto);
		SupplierDtos FindAll();
		DropBoxDtos FillDropBox();
		SupplierDto FindById(long id);
	}
}
