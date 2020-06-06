using AutoMapper;
using Rosentis.DataContract.Base;
using Rosentis.DataContract.Base.Dtos;
using Rosentis.DataContract.ExeptionModel;
using Rosentis.DataContract.Products;
using Rosentis.DataContract.Products.Dtos;
using Rosentis.DomainModel.Products;
using Rosentis.Persistance;
using Rosentis.Persistance.Facade;
using Rosentis.ServiceContract.Products;
using System;
using System.Collections.Generic;

namespace Rosentis.ServiceImplementation.Products
{
	public class ProductRelatedApplicationService : IProductRelatedService
	{
		#region Properties
		private UnitOfWork _unitOfWork = new UnitOfWork();
		#endregion Properties

		#region Ctors
		public ProductRelatedApplicationService(RosentisContext context)
		{
		}
		#endregion Ctors

		#region Utilities
		#endregion Utilities

		#region Methods
		public ProductRelatedDtos FindByProductId(long id)
		{
			return new ProductRelatedDtos
			{
				ProductRelateds = Mapper.Map<List<ProductRelatedDto>>(_unitOfWork.ProductRelatedRepository.Get(x => x.ProductId == id))
			};
		}
		public ProductRelatedDto Save(ProductRelatedDto dto)
		{
			var productRelated = new ProductRelated();

			if (dto.Id == 0)
			{
				productRelated = Mapper.Map<ProductRelated>(dto);

				_unitOfWork.ProductRelatedRepository.Insert(productRelated);
				_unitOfWork.Save();
			}
			else
			{
				productRelated = _unitOfWork.ProductRelatedRepository.GetByID(dto.Id);

				productRelated.Description = dto.Description;
				productRelated.Link = dto.Link;
				_unitOfWork.ProductRelatedRepository.Update(productRelated);
			}
			_unitOfWork.Save();

			dto.Id = productRelated.Id;

			return dto;
		}
		public DtoResponse Remove(ProductRelatedDto dto)
		{
			try
			{
				var ProductRelated = _unitOfWork.ProductRelatedRepository.GetFirst(x => x.Id == dto.Id);
				if (ProductRelated != null && ProductRelated.Id > 0)
				{
					_unitOfWork.ProductRelatedRepository.Delete(dto.Id);
					_unitOfWork.Save();
				}

				return new DtoResponse();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		#endregion Methods
	}
}
