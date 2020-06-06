using System;
using System.Collections.Generic;
using System.Linq;
using Rosentis.DataContract.AuthEntities;
using Rosentis.DataContract.Base;

namespace Rosentis.DataContract.Shop
{
    public class CartDto: BaseDto
    {
		public UserDto User {get; set;}
		public long? UserId {get; set;}
		public DateTime CreatedDate {get; set;}

		public bool CheckedOut {get; set;}
		public int CartItemCount { get; set; }
		public Guid Id {get; set;}
        public List<CartItemDto> CartItems { get; set; }
		public decimal TotalVases { get
		{
		    decimal sum = 0;
		    foreach (var item in CartItems)
		    {
					//sum += item.Vases.Sum(x=>x.Price);
					sum = 0;
		    }
		    return sum;
		}}

        public string TotalVasesMoney => TotalVases.ToString("#,##0") + " تومان";
        public string TotalVatMoney => TotalVat.ToString("#,##0") + " تومان";

        public decimal TotalVat
        {
            get
            {
                decimal sum =  (decimal)0.09 * (TotalPrice + TotalVases - TotalDiscount);
                return sum;
            }
        }

        public decimal TotalDiscount { get; set;}
        public string TotalDiscountMoney => TotalDiscount.ToString("#,##0") + " تومان";

        public decimal TotalPrice { get; set; }

        public string TotalPriceMoney => TotalPrice.ToString("#,##0") + " تومان";

        public decimal TotalPayment {
        get {
        decimal sum = (TotalPrice + TotalVases - TotalDiscount) + TotalVat;
            return sum;
            }}

        public string TotalPaymentMoney => TotalPayment.ToString("#,##0") + " تومان";

        public CartDto()
        {
            CartItems = new List<CartItemDto>();
        }

    }
}
