using Rosentis.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rosentis.DomainModel.Users
{
	[Table("Suppliers", Schema = "prj")]
	public class Supplier : Member
	{
		public string Name { get; set; }
		public string NationalID { get; set; }
		public string EconomicCode { get; set; }
		public string PostalCode { get; set; }
		public long? Fax { get; set; }
		public string Website { get; set; }
		public string Notes { get; set; }
		public string PaymentMethod { get; set; }
		public string Logo { get; set; }
		public double? Latitude { get; set; }
		public double? Longitude { get; set; }
		public CompanyType CompanyType { get; set; }
	}
}
