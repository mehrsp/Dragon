using Rosentis.DataContract.Base;
using Rosentis.DataContract.Products;
using System.Collections.Generic;

namespace Rosentis.DataContract.Products.Dtos
{
	public class TechnicalDtos: BaseDto
	{
		public List<TechnicalDto> Technicals { get; set; }

		public TechnicalDtos()
		{
			Technicals = new List<TechnicalDto>();
		}
	}
}
