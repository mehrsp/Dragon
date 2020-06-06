using Rosentis.DataContract.Base;
using System.Collections.Generic;

namespace Rosentis.DataContract.Info.Address.Dtos
{
	public class CityDtos : BaseDto
	{
		public List<CityDto> Cities { get; set; }

		public CityDtos()
		{
			Cities = new List<CityDto>();
		}
	}
}
