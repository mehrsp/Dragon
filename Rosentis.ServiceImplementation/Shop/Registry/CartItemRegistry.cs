using Rosentis.DataContract.Shop;
using Rosentis.DistributedServices;
using Rosentis.DomainModel.Shop;
using Rosentis.ServiceContract.Shop;
using Rosentis.ServiceImplementation.Shop.Mapper;

namespace Rosentis.ServiceImplementation.Shop.Registry
{
    public class CartItemRegistry : StructureMap.Registry
    {
        public CartItemRegistry()
        {
            //this.For<ICartItemService>().Use<CartItemService>();
            this.For<IEntityMapper<CartItem, CartItemDto>>().Use<CartItemMapper>();
            //this.For<ICartItemRepository>().Use<CartItemRepository>();
            this.For<ICartItemApplicationService>().Use<CartItemApplicationService>();

        }
    }
}