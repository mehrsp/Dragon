using Rosentis.DataContract.Shop;
using System;

namespace Rosentis.ServiceContract.Shop
{
    public interface IPurchaseApplicationService
    {
        PurchaseDto Save(PurchaseDto dto);
        bool Remove(PurchaseDto dto);
        PurchaseDtos FindAll();
        PurchaseDto Find(Guid id);
    }
}
