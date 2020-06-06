using Rosentis.DataContract.Base;
using System;

namespace Rosentis.DataContract.Shop
{
    public class PurchaseDto: BaseDto
    {
		public string ProductNumber {get; set;}
		public string ProductName {get; set;}
		public int Qauntity {get; set;}
		public Decimal Price {get; set;}
		public Decimal Vat {get; set;}
		public Decimal Discount {get; set;}
		public ProviderDto Provider {get; set;}
		public Guid ProviderId {get; set;}
		public int CommisionPercentage {get; set;}
		public string Notes {get; set;}
		public DateTime CreatedDate {get; set;}
		public PurchaseTypeDto PurchaseType {get; set;}
		public int PurchaseTypeId {get; set;}
		public InvoiceDto Invoice {get; set;}
		public Guid InvoiceId {get; set;}
		public bool CheckedOut {get; set;}
		public DateTime? CheckedOutDate {get; set;}
		public Guid Id {get; set;}

    }
}
