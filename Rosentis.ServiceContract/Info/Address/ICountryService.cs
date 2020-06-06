using Rosentis.DataContract.Base.Dtos;
using Rosentis.DataContract.Info.Address;
using Rosentis.DataContract.Info.Address.Dtos;
namespace Rosentis.ServiceContract.Info.Address
{
	public interface ICountryService
	{
		CountryDtos FindAll();
		CountryDto FindById(int id);
		DropBoxDtos FillDropBox();
	}
}
