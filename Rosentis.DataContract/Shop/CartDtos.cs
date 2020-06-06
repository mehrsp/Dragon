using Rosentis.DataContract.Base;
using System.Collections.Generic;
namespace Rosentis.DataContract.Shop
{
    public class CartDtos: BaseDto
    {
        public List<CartDto> Carts { get; set; }

        public CartDtos()
        {
            Carts = new List<CartDto>();
        }
    }
}
