using System;
using Rosentis.DataContract.Shop;

namespace Rosentis.ServiceContract.Shop
{
    public interface ICartItemApplicationService
	{
        CartItemDto Save(CartItemDto dto);
        bool Remove(CartItemDto dto);
        CartItemDtos FindAll();
        CartItemDto Find(Guid id);
        CartItemDto SaveOrUpdate(CartItemDto cartItem);
		CartItemDtos FindChilds(Guid id);
		CartItemDto FindByProductId(Guid id, long productId);
	}
}

