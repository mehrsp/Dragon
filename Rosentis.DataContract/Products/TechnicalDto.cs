using Rosentis.DataContract.Base;
using System.Collections.Generic;

namespace Rosentis.DataContract.Products
{
	public class TechnicalDto: BaseDto
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public int? ParentId { get; set; }
		public TechnicalDto Parent { get; set; }

	}
}
