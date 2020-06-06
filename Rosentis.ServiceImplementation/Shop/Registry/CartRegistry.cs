using Rosentis.DataContract.Shop;
using Rosentis.DistributedServices;
using Rosentis.DomainModel.Shop;
using Rosentis.ServiceContract.Shop;
using Rosentis.ServiceImplementation.Shop.Mapper;

namespace Rosentis.ServiceImplementation.Shop.Registry
{
    public class CartRegistry : StructureMap.Registry
    {
        public CartRegistry()
        {
            //this.For<ICartService>().Use<CartService>();
            this.For<IEntityMapper<Cart, CartDto>>().Use<CartMapper>();
            //this.For<ICartRepository>().Use<CartRepository>();
            this.For<ICartApplicationService>().Use<CartApplicationService>();

        }
    }
}