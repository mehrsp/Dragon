using Rosentis.DataContract.Base;
using System.Collections.Generic;
namespace Rosentis.DataContract.Shop
{
    public class InvoiceDtos: BaseDto
    {
        public List<InvoiceDto> Invoices { get; set; }

        public InvoiceDtos()
        {
            Invoices = new List<InvoiceDto>();
        }
    }
}
