using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rosentis.DataContract.Shop;
using Rosentis.DomainModel.Shop;
using Rosentis.DomainModel.Shop.NullObjects;
using Rosentis.DataContract.Products;
using Rosentis.DomainModel.Products;
using Rosentis.DistributedServices;

namespace Rosentis.ServiceImplementation.Shop.Mapper
{
    public class CartItemMapper : IEntityMapper<CartItem, CartItemDto>
    {
		private IEntityMapper<Cart, CartDto> _cartMapper;
		private IEntityMapper<Product, ProductDto> _productMapper;

        public CartItemMapper(IEntityMapper<Cart, CartDto> cartMapper,
            IEntityMapper<Product, ProductDto> productMapper
            )
        {
		_cartMapper = cartMapper;
		_productMapper = productMapper;
        }
		public CartItem CreateFrom(CartItemDto domainDto)
		{
			if (domainDto == null)
				return new NullCartItem();
			return new CartItem();

		}

		public CartItemDto MapTo(CartItem domain)
		{
			CartItemDto domainDto = new CartItemDto();
			if (domain != null)
			{
				//if (domain.Cart != null) domainDto.Cart = _cartMapper.MapTo(domain.Cart);
				if (domain.Product != null) domainDto.Product = _productMapper.MapTo(domain.Product);
				domainDto.Quantity = domain.Quantity;
				domainDto.Price = domain.Price;
				domainDto.Vat = domain.Vat;
				domainDto.Discount = domain.Discount;
				domainDto.CartId = domain.CartId;
				domainDto.ProductId = domain.ProductId;
				domainDto.Notes = domain.Notes;
				domainDto.CreatedDate = domain.CreatedDate;
				
				domainDto.Id = domain.Id;

			}

			return domainDto;
		}
	}

}