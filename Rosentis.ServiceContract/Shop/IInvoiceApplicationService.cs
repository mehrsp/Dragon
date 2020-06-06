using System;
using Rosentis.DataContract.Shop;

namespace Rosentis.ServiceContract.Shop
{
    public interface IInvoiceApplicationService
    {
        InvoiceDto Save(InvoiceDto dto);
        bool Remove(InvoiceDto dto);
        InvoiceDtos FindAll();
        InvoiceDto Find(Guid id);
    }
}
