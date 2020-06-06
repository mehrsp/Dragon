namespace Rosentis.DomainModel.Products
{
	public class ProductTechnical
	{
		public long Id { get; set; }
		public string Name { get; set; }
		public virtual Product Product { get; set; }
		public long ProductId { get; set; }
		public virtual Technical Technical { get; set; }
		public int? TechnicalId { get; set; }
		public string Description { get; set; }
		public bool IsChecked { get; set; }
		public bool IsValid { get; set; }
	}
}
