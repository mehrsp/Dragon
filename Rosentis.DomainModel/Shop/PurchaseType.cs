using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rosentis.DomainModel.Shop
{
    public class PurchaseType
	{
		public PurchaseType(string name, string description, ICollection<Purchase> purchases, int id)
		{
			Name = name;
			Description = description;
			Purchases = purchases;
			Id = id;
			if (Purchases == null)
			{
				Purchases = new List<Purchase>();
			}
		}
		protected PurchaseType()
		{
		}
		public   int Id { get; set; }		
		public string Name {get; set;}
		public string Description {get; set;}
		public ICollection<Purchase> Purchases {get; set;}
    }
}
