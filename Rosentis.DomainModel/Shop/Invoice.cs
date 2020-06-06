using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Rosentis.DomainModel.AuthEntities;

namespace Rosentis.DomainModel.Shop
{
    public class Invoice
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public  Guid Id { get; set; }
        protected Invoice()
        {
            InvoiceDetails = new List<InvoiceDetails>();
        }
		public Invoice(long invoiceNumber, Customer customer, User user, long? userId, string notes, DateTime createdDate, DateTime? dueDate, bool paid, string purchaseType, ICollection<InvoiceDetails> invoiceDetails, Guid id)
		{
			InvoiceNumber = invoiceNumber;
			Customer = customer;
			User = user;
			UserId = userId;
			Notes = notes;
			CreatedDate = createdDate;
			DueDate = dueDate;
			Paid = paid;
			PurchaseType = purchaseType;
			InvoiceDetails = invoiceDetails;
			Id = id;
			if (invoiceDetails == null)
			{
				InvoiceDetails = new List<InvoiceDetails>();
			}
		}
		public long InvoiceNumber {get; set;}
		public virtual Customer Customer {get; set;}
		public virtual User User {get; set;}
		public long? UserId {get; set;}
		public string Notes {get; set;}
		public DateTime CreatedDate {get; set;}
		public DateTime? DueDate {get; set;}
		public bool Paid {get; set;}
		public string PurchaseType {get; set;}
		public virtual ICollection<InvoiceDetails> InvoiceDetails {get; set;}

    }
}
