using Rosentis.Common;

namespace Rosentis.DataContract.Users
{
	public class SupplierDto : MemberDto
	{
		public string Name { get; set; }
		public string NationalID { get; set; }
		public string EconomicCode { get; set; }
		public string PostalCode { get; set; }
		public long Fax { get; set; }
		public string Website { get; set; }
		public string Notes { get; set; }
		public string PaymentMethod { get; set; }
		public string Logo { get; set; }
		public double Latitude { get; set; }
		public double Longitude { get; set; }
		public CompanyType CompanyType { get; set; }
	}
}
