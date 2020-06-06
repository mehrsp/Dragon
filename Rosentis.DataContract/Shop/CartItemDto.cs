using System;
using System.Collections.Generic;
using Rosentis.DataContract.Products;
using PersianDate;
using Rosentis.DataContract.Base;

namespace Rosentis.DataContract.Shop
{
    public class CartItemDto: BaseDto
    {
        public CartItemDto()
        {
        }
        public Guid CartId { get; set; }
		public ProductDto Product {get; set;}
        public DateTime CreatedDate { get; set; }
		public int Quantity {get; set;}
		public decimal Price {get; set;}
		public Guid ParentId { get; set; }
		public decimal Vat {get; set;}
		public decimal Discount {get; set;}
        public string Notes { get; set; }		
		public Guid Id {get; set;}
        public long ProductId { get; set; }
        public decimal PriceWithDiscount => (Product.Price - (Product.Price * (Discount / 100))) * Quantity;
		public string PriceWithDiscountMoney => ((Product.Price - (Product.Price * (Discount / 100))) * Quantity).ToString("#,##0") + " تومان";
	}
}
