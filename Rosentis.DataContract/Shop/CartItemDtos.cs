using Rosentis.DataContract.Base;
using System.Collections.Generic;
namespace Rosentis.DataContract.Shop
{
    public class CartItemDtos: BaseDto
    {
        public List<CartItemDto> CartItems { get; set; }

        public CartItemDtos()
        {
            CartItems = new List<CartItemDto>();
        }
    }
}
