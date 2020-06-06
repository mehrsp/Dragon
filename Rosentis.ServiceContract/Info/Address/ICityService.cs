using Rosentis.DataContract.Base.Dtos;
using Rosentis.DataContract.Info.Address.Dtos;
namespace Rosentis.ServiceContract.Info.Address
{
	public interface ICityService
	{
		CityDtos FindAll();
		DropBoxDtos FillDropBox();
		DropBoxDtos FindByProvinceId(int provinceId);

	}
}
