using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Rosentis.DataContract.AuthEntities;
using PersianDate;
using Rosentis.DataContract.Base;

namespace Rosentis.DataContract.Shop
{
    public class InvoiceDto: BaseDto
    {
		public long InvoiceNumber {get; set;}
		public CustomerDto Customer {get; set;}
		public Guid? CustomerId {get; set;}
		public UserDto User {get; set;}
		public long? UserId {get; set;}
		public string Notes {get; set;}
		public DateTime CreatedDate {get; set;}
        public string CreatedDateShamsi => CreatedDate.ToFa();
		public DateTime? DueDate {get; set;}
        public string DueDateShamsi => DueDate.HasValue ? DueDate.Value.ToFa() : "";
        public bool Paid {get; set;}
		public string PurchaseType {get; set;}
		public ICollection<InvoiceDetailsDto> InvoiceDetails {get; set;}
		public Guid Id {get; set;}

        public InvoiceDto()
        {
            InvoiceDetails = new List<InvoiceDetailsDto>();
        }
        #region Calculated fields

        [DisplayName("مالیات")]
        public string VatAmountMoney => VatAmount.ToString("0,00#") + " تومان";
        public decimal VatAmount => TotalWithVat - NetTotal;

        /// <summary>
        /// Total before TAX
        /// </summary>
        [DisplayName("قیمت خالص")]
        public string NetTotalMoney => NetTotal.ToString("0,00#") + " تومان";
        public decimal NetTotal => InvoiceDetails?.Sum(i => i.Total) ?? 0;

        /// <summary>
        /// Total with tax
        /// </summary>
        [DisplayName("قیمت با مالیات")]
        public string TotalWithVatMoney => TotalWithVat.ToString("0,00#") + " تومان";
        public decimal TotalWithVat => InvoiceDetails?.Sum(i => i.TotalPlusVat) ?? 0;

        [DisplayName("قیمت با تخفیف")]
        public string TotalWithDiscountMoney => TotalWithDiscount.ToString("0,00#") + " تومان";
        public decimal TotalWithDiscount => InvoiceDetails.Sum(i => i.TotalWithDiscount);
        [DisplayName("تخفیف")]
        public string TotalDiscountMoney => TotalDiscount.ToString("0,00#") + " تومان";
        public decimal TotalDiscount => InvoiceDetails.Sum(i => i.TotalDiscount);
        /// <summary>
        /// Total with VAT minus advanced tax payment 
        /// </summary>
        [DisplayName("قیمت کل")]
        public string TotalToPayMoney => TotalToPay.ToString("0,00#") + " تومان";
        public decimal TotalToPay => TotalWithVat;
        #endregion
    }
}
