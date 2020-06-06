using Rosentis.DataContract.Base;
using System.Collections.Generic;

namespace Rosentis.DataContract.Brands.Dtos
{
	public class BrandDtos: BaseDto
	{
		public List<BrandDto> Brands { get; set; }

		public BrandDtos()
		{
			Brands = new List<BrandDto>();
		}
	}
}
