using Rosentis.DataContract.Base;

namespace Rosentis.DataContract.Products
{
	public class ProductTechnicalDto: BaseDto
	{
		public long Id { get; set; }
		public long ProductId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public bool IsChecked { get; set; }
		public bool IsValid { get; set; }
		public int? TechnicalId { get; set; }
		public TechnicalDto Technical { get; set; }
	}
}
