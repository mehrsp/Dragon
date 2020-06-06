using Rosentis.DataContract.Base;
using Rosentis.DataContract.Info.Address;

namespace Rosentis.DataContract.Brands
{
	public class BrandDto: BaseDto
	{
		public int? Id { get; set; }
		public string Name { get; set; }
		public string Logo { get; set; }
		public int Priority { get; set; }
		public string Description { get; set; }
		public virtual CountryDto Country { get; set; }
		public int CountryId { get; set; }
	}
}
