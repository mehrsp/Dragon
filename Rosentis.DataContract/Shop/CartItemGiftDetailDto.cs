using Rosentis.DataContract.Base;
using System;

namespace Rosentis.DataContract.Shop
{
    public class CartItemGiftDetailDto: BaseDto
    {
		public Guid Id {get; set;}
		public CartItemDto CartItem {get; set;}

    }
}
