using Rosentis.DataContract.Shop;
using System;

namespace Rosentis.ServiceContract.Shop
{
    public interface IProviderApplicationService
    {
        ProviderDto Save(ProviderDto dto);
        bool Remove(ProviderDto dto);
        ProviderDtos FindAll();
        ProviderDto Find(Guid id);
    }
}
