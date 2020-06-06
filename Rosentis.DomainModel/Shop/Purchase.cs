using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace Rosentis.DomainModel.Shop
{
    public class Purchase
	{
        public  Guid Id { get; set; }
        protected Purchase()
        {

        }
		public Purchase(string productNumber, string productName, int qauntity, Decimal price, Decimal vat, Decimal discount, Provider provider, Guid providerId, int commisionPercentage, string notes, DateTime createdDate, PurchaseType purchaseType, int purchaseTypeId, Invoice invoice, Guid invoiceId, bool checkedOut, DateTime? checkedOutDate, Guid id)
		{
			ProductNumber = productNumber;
			ProductName = productName;
			Qauntity = qauntity;
			Price = price;
			Vat = vat;
			Discount = discount;
			Provider = provider;
			ProviderId = providerId;
			CommisionPercentage = commisionPercentage;
			Notes = notes;
			CreatedDate = createdDate;
			PurchaseType = purchaseType;
			PurchaseTypeId = purchaseTypeId;
			Invoice = invoice;
			InvoiceId = invoiceId;
			CheckedOut = checkedOut;
			CheckedOutDate = checkedOutDate;
			Id = id;
		}
		public string ProductNumber {get; set;}
		public string ProductName {get; set;}
		public int Qauntity {get; set;}
		public Decimal Price {get; set;}
		public Decimal Vat {get; set;}
		public Decimal Discount {get; set;}
		public virtual Provider Provider {get; set;}
		public Guid ProviderId {get; set;}
		public int CommisionPercentage {get; set;}
		public string Notes {get; set;}
		public DateTime CreatedDate {get; set;}
		public virtual PurchaseType PurchaseType {get; set;}
		public int PurchaseTypeId {get; set;}
		public virtual Invoice Invoice {get; set;}
		public Guid InvoiceId {get; set;}
		public bool CheckedOut {get; set;}
		public DateTime? CheckedOutDate {get; set;}
    }
}
