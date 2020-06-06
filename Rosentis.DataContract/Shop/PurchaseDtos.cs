using Rosentis.DataContract.Base;
using System.Collections.Generic;
namespace Rosentis.DataContract.Shop
{
    public class PurchaseDtos: BaseDto
    {
        public List<PurchaseDto> Purchases { get; set; }

        public PurchaseDtos()
        {
            Purchases = new List<PurchaseDto>();
        }
    }
}
