using Rosentis.DataContract.Base;
using System.Collections.Generic;

namespace Rosentis.DataContract.Products
{
	public class TechnicalChildDto: BaseDto
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public int? ParentId { get; set; }
		public List<TechnicalChildDto> Children { get; set; }

	}
}
