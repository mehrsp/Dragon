using Rosentis.DataContract.Base;
using System.Collections.Generic;

namespace Rosentis.DataContract.Info.Address.Dtos
{
	public class ProvinceDtos : BaseDto
	{
		public List<ProvinceDto> Provinces { get; set; }

		public ProvinceDtos()
		{
			Provinces = new List<ProvinceDto>();
		}
	}
}
