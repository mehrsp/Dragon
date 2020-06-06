using Rosentis.DataContract.Base;
using Rosentis.DataContract.Base.Dtos;
using Rosentis.DataContract.Brands;
using Rosentis.DataContract.Brands.Dtos;

namespace Rosentis.ServiceContract.Brands
{
	public interface IBrandService
	{
		BrandDto Save(BrandDto dto);
		DtoResponse Remove(BrandDto dto);
		BrandDtos FindAll();
		BrandDtos FindSpecials();
		DropBoxDtos FillDropBox();
		BrandDto FindById(long id);
		BrandDto FindByName(string name);
	}
}
