using AutoMapper;
using Rosentis.DataContract.Base;
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
	public class ProductImageApplicationService : IProductImageService
	{
		#region Properties
		private UnitOfWork _unitOfWork = new UnitOfWork();
		#endregion

		#region Ctors
		public ProductImageApplicationService(RosentisContext context) 
        {
		}
		#endregion

		#region Utilities
		#endregion

		#region Methods
		public ProductImageDtos FindByProductId(long id)
		{
			return new ProductImageDtos
			{
				ProductImages = Mapper.Map<List<ProductImageDto>>(_unitOfWork.ProductImageRepository.Get(x => x.ProductId == id))
			};
		}
		public ProductImageDto Save(ProductImageDto dto)
		{
			var ProductImage = new ProductImage();
			ProductImage = Mapper.Map<ProductImage>(dto);
			ProductImage.CreatedDate = DateTime.Now;

			_unitOfWork.ProductImageRepository.Insert(ProductImage);
			_unitOfWork.Save();

			dto.Id = ProductImage.Id;

			return dto;
		}
		public DtoResponse Remove(ProductImageDto dto)
		{
			try
			{
				var ProductImage = _unitOfWork.ProductImageRepository.GetFirst(x => x.Id == dto.Id);
				if (ProductImage != null && ProductImage.Id > 0)
				{
					_unitOfWork.ProductImageRepository.Delete(dto.Id);
					_unitOfWork.Save();
				}

				return new DtoResponse();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		#endregion
	}
}
