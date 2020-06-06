using System;
using Rosentis.DataContract.Products;
using Rosentis.DataContract.Base;

namespace Rosentis.DataContract.Shop
{
    public class InvoiceDetailsDto: BaseDto
    {
		public InvoiceDto Invoice {get; set;}
		public Guid InvoiceId {get; set;}
		public ProductDto Product {get; set;}
		public long? ProductId {get; set;}
        public long? VaseId { get; set; }
        public ProductInvoiceTypeDto ProductInvoiceType { get; set; }
        public int ProductInvoiceTypeId { get; set; }
		public string ProductNumber {get; set;}
		public string ProductName {get; set;}
		public int Qauntity {get; set;}
        public string PriceMoney => Price.ToString("0,00#") + " تومان";
		public Decimal Price {get; set;}
        public string VatMoney => Vat.ToString("0,00#") + " تومان";
		public Decimal Vat {get; set;}
        public string DiscountMoney => Discount.ToString("0,00#") + " تومان";
		public Decimal Discount {get; set;}
		public DateTime CreatedDate {get; set;}
		public Guid Id {get; set;}
        public InvoiceDetailsFlowerDto InvoiceDetailsFlower { get; set; }
        public InvoiceDetailsCakeDto InvoiceDetailsCake { get; set; }
        public InvoiceDetailsGiftDto InvoiceDetailsGift { get; set; }
        #region Calculated fields
        public string TotalMoney => Total.ToString("0,00#") + " تومان";
        public decimal Total => Qauntity * Price;

        public string VatAmountMoney => VatAmount.ToString("0,00#") + " تومان";
        public decimal VatAmount => TotalPlusVat - Total;
        public string TotalPlusVatMoney => TotalPlusVat.ToString("0,00#") + " تومان";

        public decimal TotalPlusVat => Total * (1 + Vat / 100);
        public string TotalWithDiscountMoney => TotalWithDiscount.ToString("0,00#") + " تومان";
        public decimal TotalWithDiscount => Total - (Total * (Discount / 100));
        public string TotalDiscountMoney => TotalDiscount.ToString("0,00#") + " تومان";
        public decimal TotalDiscount => (Total * Discount / 100);
        public decimal TotalToPay => TotalDiscount * (1 + Vat / 100);

        #endregion

    }
}
