using System;
using System.Linq;
using Rosentis.DataContract.Shop;
using Rosentis.ServiceContract.Shop;
using Rosentis.Persistance;
using Rosentis.Persistance.Facade;
using Rosentis.DomainModel.Shop;
using System.Collections.Generic;

namespace Rosentis.ServiceImplementation.Shop
{
    public class CartItemApplicationService : ICartItemApplicationService
    {
		#region Properties
		private UnitOfWork _unitOfWork = new UnitOfWork();
		#endregion Properties

		#region Ctors
		public CartItemApplicationService(RosentisContext context)
		{
		}
		#endregion Ctors
		#region Methods
		public CartItemApplicationService()
		{

		}

		public CartItemDto Find(Guid id)
		{
			return AutoMapper.Mapper.Map<CartItemDto>(_unitOfWork.CartItemRepository.Get(x => x.Id == id).FirstOrDefault());
		}
		public CartItemDto FindByProductId(Guid id, long productId)
		{
			return AutoMapper.Mapper.Map<CartItemDto>(_unitOfWork.CartItemRepository.Get(x => x.CartId == id && x.ProductId == productId).FirstOrDefault());
		}
		public CartItemDtos FindChilds(Guid id)
		{
			return new CartItemDtos
			{
				CartItems = AutoMapper.Mapper.Map<List<CartItemDto>>(_unitOfWork.CartItemRepository.Get(x => x.ParentId == id).ToList())
			};
		}

		public CartItemDto SaveOrUpdate(CartItemDto cartItem)
		{
			if (cartItem.Id == Guid.Empty)
			{
				var cart = _unitOfWork.CartItemRepository.Insert(AutoMapper.Mapper.Map<CartItem>(cartItem));
				_unitOfWork.Save();
				cartItem.Id = cart.Id;
			}
			else
			{
				var cart = _unitOfWork.CartItemRepository.GetByID(cartItem.Id);
				cart.Quantity = cartItem.Quantity;
				_unitOfWork.CartItemRepository.Update(cart);
				_unitOfWork.Save();
			}
			return cartItem;
		}

		public CartItemDtos FindAll()
		{
			return new CartItemDtos
			{
				CartItems = AutoMapper.Mapper.Map<List<CartItemDto>>(_unitOfWork.CartItemRepository.Get().ToList())
			};
		}

		public CartItemDto Save(CartItemDto dto)
		{
			var cartIt = _unitOfWork.CartItemRepository.Insert(AutoMapper.Mapper.Map<CartItem>(dto));
			_unitOfWork.Save();
			dto.Id = cartIt.Id;
			return dto;
		}

		public bool Remove(CartItemDto dto)
		{
			try
			{
				_unitOfWork.CartItemRepository.Delete(dto.Id);
				_unitOfWork.Save();
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		#endregion
	}
}
