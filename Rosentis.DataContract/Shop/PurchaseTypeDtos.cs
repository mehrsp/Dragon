using Rosentis.DataContract.Base;
using System.Collections.Generic;
namespace Rosentis.DataContract.Shop
{
    public class PurchaseTypeDtos: BaseDto
    {
        public List<PurchaseTypeDto> PurchaseTypes { get; set; }

        public PurchaseTypeDtos()
        {
            PurchaseTypes = new List<PurchaseTypeDto>();
        }
    }
}
