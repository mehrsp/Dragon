using System.Collections.Generic;

namespace Rosentis.DataContract.Shop
{
    public class AddToCartRequestDto
    {
        public long ProductId { get; set; }
		public string Notes { get; set; }
		public int Quantity { get; set; }
		public int TotalPrice { get; set; }
		public List<AddToCartRequestDto> Children { get; set; }
	}
}
