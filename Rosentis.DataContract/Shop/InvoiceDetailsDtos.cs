using Rosentis.DataContract.Base;
using System.Collections.Generic;
namespace Rosentis.DataContract.Shop
{
    public class InvoiceDetailsDtos: BaseDto
    {
        public List<InvoiceDetailsDto> InvoiceDetailss { get; set; }

        public InvoiceDetailsDtos()
        {
            InvoiceDetailss = new List<InvoiceDetailsDto>();
        }
    }
}
