using Rosentis.DataContract.Base;
using System;

namespace Rosentis.DataContract.Products
{
	public class ProductImageDto : BaseDto
	{
		public long Id { get; set; }
		public string Title { get; set; }
		public long ProductId { get; set; }
		public string Photo { get; set; }
	}
}
