using Rosentis.DomainModel.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rosentis.DomainModel.Shop
{
    public class CartItem
    {
        public  Guid Id { get; set; }
  		public CartItem() 
		{
		}
		public Cart Cart {get; set;}
		public virtual Product Product {get; set;}
		public long ProductId {get; set;}
		public Guid? ParentId { get; set; }
		public DateTime CreatedDate { get; set; }
        public string Notes { get; set; }
		public int Quantity {get; set;}
		public Decimal Price {get; set;}
		public Decimal Vat {get; set;}
		public Decimal Discount {get; set;}
        public Guid CartId { get; set; }
        public void Update(decimal vat, decimal discount, decimal price, int quantity, string notes)
        {
            Vat = vat;
            Discount = discount;
            Price = price;
            Quantity = quantity;
            Notes = notes;
        }
    }
}
