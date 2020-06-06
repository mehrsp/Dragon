using Rosentis.DataContract.Base;
using System.Collections.Generic;

namespace Rosentis.DataContract.Info.Address.Dtos
{
	public class CountryDtos : BaseDto
	{
		public List<CountryDto> Countries { get; set; }

		public CountryDtos()
		{
			Countries = new List<CountryDto>();
		}
	}
}
