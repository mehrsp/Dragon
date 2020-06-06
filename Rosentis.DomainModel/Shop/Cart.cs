using System;
using System.ComponentModel.DataAnnotations.Schema;
using Rosentis.DomainModel.AuthEntities;
using System.Collections.Generic;

namespace Rosentis.DomainModel.Shop
{
    public class Cart
    {
        public Guid Id { get; set; }
		public Cart(User user, long? userId, DateTime createdDate, bool checkedOut, Guid id)
		{
			User = user;
			UserId = userId;
			CreatedDate = createdDate;
			CheckedOut = checkedOut;
			Id = id;
		}
		protected Cart()
		{
		}
		public virtual User User {get; set;}
		public long? UserId {get; set;}
		public DateTime CreatedDate {get; set;}
		public bool CheckedOut {get; set;}
		public virtual ICollection<CartItem> CartItems { get; set; }
	}
}
