using Rosentis.DomainModel.Products;
using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace Rosentis.DomainModel.Shop
{
    public class InvoiceDetails
    {
        public  Guid Id { get; set; }
        protected InvoiceDetails()
        {

        }
		public InvoiceDetails(Invoice invoice, Guid invoiceId, Product product, 
			long? productId, string productNumber, string productName, int qauntity, 
			Decimal price, Decimal vat, Decimal discount, ProductInvoiceType productInvoiceType, 
			int productInvoiceTypeId, DateTime createdDate, Guid id)
		{
			Invoice = invoice;
			InvoiceId = invoiceId;
			Product = product;
			ProductId = productId;
			ProductNumber = productNumber;
			ProductName = productName;
			Qauntity = qauntity;
			Price = price;
			Vat = vat;
			Discount = discount;
			CreatedDate = createdDate;
			Id = id;
			ProductInvoiceType = productInvoiceType;
			ProductInvoiceTypeId = productInvoiceTypeId;
		}
		public virtual Invoice Invoice {get; set;}
		public Guid InvoiceId {get; set;}
		public virtual Product Product {get; set;}
		public long? ProductId {get; set;}
        public virtual ProductInvoiceType ProductInvoiceType { get; set; }
        public int ProductInvoiceTypeId { get; set; }
        public string ProductNumber {get; set;}
		public string ProductName {get; set;}
		public int Qauntity {get; set;}
		public Decimal Price {get; set;}
		public Decimal Vat {get; set;}
		public Decimal Discount {get; set;}
		public DateTime CreatedDate {get; set;}
    }
}
