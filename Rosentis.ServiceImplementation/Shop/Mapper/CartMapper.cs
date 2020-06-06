using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rosentis.DataContract.Shop;
using Rosentis.DomainModel.Shop;
using Rosentis.DomainModel.Shop.NullObjects;
using Rosentis.DataContract.AuthEntities;
using Rosentis.DomainModel.AuthEntities;
using Rosentis.DistributedServices;

namespace Rosentis.ServiceImplementation.Shop.Mapper
{
    public class CartMapper : IEntityMapper<Cart, CartDto>
    {
		private IEntityMapper<User, UserDto> _userMapper;

        public CartMapper(IEntityMapper<User, UserDto> userMapper)
        {
		_userMapper = userMapper;

        }
        public Cart CreateFrom(CartDto domainDto)
        {
            if (domainDto == null)
                return new NullCart();
            return new Cart(null,domainDto.UserId,domainDto.CreatedDate,domainDto.CheckedOut,domainDto.Id);

        }

        public CartDto MapTo(Cart domain)
        {
            CartDto domainDto = new CartDto();
            if (domain != null)
            {
				if(domain.User!=null)domainDto.User = _userMapper.MapTo(domain.User);
				domainDto.UserId = domain.UserId;
				domainDto.CreatedDate = domain.CreatedDate;
				domainDto.CheckedOut = domain.CheckedOut;
				domainDto.Id = domain.Id;

            }

            return domainDto;
        }
    }

}