using Rosentis.DataContract.Base.Dtos;
using Rosentis.DataContract.Info.Address.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rosentis.ServiceContract.Info.Address
{
	public interface IProvinceService
	{
		ProvinceDtos FindAll();
		DropBoxDtos FillDropBox();
	}
}
