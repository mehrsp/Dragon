using Rosentis.DataContract.Base;
using Rosentis.DataContract.Products;
using System.Collections.Generic;

namespace Rosentis.DataContract.Products.Dtos
{
	public class TechnicalChildDtos : BaseDto
	{
		public List<TechnicalChildDto> Technicals { get; set; }

		public TechnicalChildDtos()
		{
			Technicals = new List<TechnicalChildDto>();
		}
	}
}
