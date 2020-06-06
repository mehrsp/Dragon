using Rosentis.DataContract.Base;
using System;

namespace Rosentis.DataContract.Shop
{
    public class CartItemCakeDetailDto: BaseDto
    {
		public Guid Id {get; set;}
		public CartItemDto CartItem {get; set;}
		public string Text {get; set;}

    }
}
