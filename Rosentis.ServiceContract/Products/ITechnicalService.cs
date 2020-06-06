using Rosentis.DataContract.Base;
using Rosentis.DataContract.Base.Dtos;
using Rosentis.DataContract.Brands;
using Rosentis.DataContract.Products;
using Rosentis.DataContract.Products.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rosentis.ServiceContract.Products
{
	public interface ITechnicalService
	{
		TechnicalDto Save(TechnicalDto dto);
		DtoResponse Remove(TechnicalDto dto);
		TechnicalDtos FindAll();
		TechnicalDto FindById(int id);
		DropBoxDtos FillDropBox();
		DropBoxDtos FillDropBoxByTechnicalId(int id);
		TechnicalDtos FindByTechnicalId(int id);
	}
}
