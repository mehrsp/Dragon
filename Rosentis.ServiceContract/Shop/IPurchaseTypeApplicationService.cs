using Rosentis.DataContract.Shop;

namespace Rosentis.ServiceContract.Shop
{
    public interface IPurchaseTypeApplicationService
    {
        PurchaseTypeDto Save(PurchaseTypeDto dto);
        bool Remove(PurchaseTypeDto dto);
        PurchaseTypeDtos FindAll();
        PurchaseTypeDto Find(int id);
    }
}
