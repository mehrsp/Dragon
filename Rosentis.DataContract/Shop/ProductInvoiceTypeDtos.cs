using Rosentis.DataContract.Base;
using System.Collections.Generic;

namespace Rosentis.DataContract.Shop
{
    public class ProductInvoiceTypeDtos: BaseDto
    {
        public List<ProductInvoiceTypeDto> ProductInvoiceTypes { get; set; }

        public ProductInvoiceTypeDtos()
        {
            ProductInvoiceTypes = new List<ProductInvoiceTypeDto>();
        }
    }
}
