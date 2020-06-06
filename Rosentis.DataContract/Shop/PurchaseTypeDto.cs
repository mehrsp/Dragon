using Rosentis.DataContract.Base;
using System.Collections.Generic;

namespace Rosentis.DataContract.Shop
{
    public class PurchaseTypeDto: BaseDto
    {
		public string Name {get; set;}
		public string Description {get; set;}
		public ICollection<PurchaseDto> Purchases {get; set;}
		public int Id {get; set;}

    }
}
