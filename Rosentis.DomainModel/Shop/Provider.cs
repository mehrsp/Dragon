using Rosentis.DomainModel.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rosentis.DomainModel.Shop
{
    public class Provider
    {
        public   Guid Id { get; set; }
        protected Provider()
        {
            Purchases = new List<Purchase>();
        }
		public Provider(Supplier supplier, long? supplierId, string address, string phone, string cell, string email, string supplierName, DateTime createdDate, ICollection<Purchase> purchases, Guid id)
		{
			Supplier = supplier;
			SupplierId = supplierId;
			Address = address;
			Phone = phone;
			Cell = cell;
			Email = email;
			CreatedDate = createdDate;
			Purchases = purchases;
			SupplierName = supplierName;
			Id = id;
			if (purchases == null)
			{
				Purchases = new List<Purchase>();
			}
		}
		public virtual Supplier Supplier {get; set;}
		public long? SupplierId {get; set;}
		public string SupplierName { get; set;}
		public string Address {get; set;}
		public string Phone {get; set;}
		public string Cell {get; set;}
		public string Email {get; set;}
		public DateTime CreatedDate {get; set;}
		public ICollection<Purchase> Purchases {get; set;}
    }
}
