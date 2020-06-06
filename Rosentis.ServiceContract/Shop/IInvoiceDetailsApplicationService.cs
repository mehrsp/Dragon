using System;
using Rosentis.DataContract.Shop;
using Rosentis.DomainModel.Shop;

namespace Rosentis.ServiceContract.Shop
{
    public interface IInvoiceDetailsApplicationService
    {
        InvoiceDetailsDto Save(InvoiceDetailsDto dto);
        bool Remove(InvoiceDetailsDto dto);
        InvoiceDetailsDtos FindAll();
        InvoiceDetailsDto Find(Guid id);
    }
}
