using System;
using System.Linq;
using Rosentis.DataContract.Shop;
using Rosentis.DomainModel.Shop;
using Rosentis.ServiceContract.Shop;
using Rosentis.Persistance;
using Rosentis.Persistance.Facade;
using System.Collections.Generic;

namespace Rosentis.ServiceImplementation.Shop
{
    public class CartApplicationService : ICartApplicationService
    {
		#region Properties
		private UnitOfWork _unitOfWork = new UnitOfWork();
		#endregion Properties

		#region Ctors
		public CartApplicationService(RosentisContext context)
		{
		}
		#endregion Ctors

		#region Methods
		public CartDto Find(Guid id)
		{
			var test = _unitOfWork.CartRepository.Get(x => x.Id == id).FirstOrDefault();
			return AutoMapper.Mapper.Map<CartDto>(test);
		}

		public CartDtos FindAll()
		{
			return new CartDtos
			{
				Carts = AutoMapper.Mapper.Map<List<CartDto>>(_unitOfWork.CartRepository.Get().ToList())
			};
		}

		public bool Remove(CartDto dto)
		{
			try
			{
				_unitOfWork.CartRepository.Delete(dto.Id);
				_unitOfWork.Save();
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
	    }

		public CartDto Save(CartDto dto)
		{
			var cart = _unitOfWork.CartRepository.Insert(AutoMapper.Mapper.Map<Cart>(dto));
			_unitOfWork.Save();
			dto.Id = cart.Id;
			return dto;
		}
		
		#endregion
	}
}
