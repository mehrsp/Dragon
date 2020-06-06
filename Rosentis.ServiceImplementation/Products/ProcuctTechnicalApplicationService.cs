using AutoMapper;
using Rosentis.DataContract.Base;
using Rosentis.DataContract.ExeptionModel;
using Rosentis.DataContract.Products;
using Rosentis.DataContract.Products.Dtos;
using Rosentis.DomainModel.Products;
using Rosentis.Persistance;
using Rosentis.Persistance.Facade;
using Rosentis.ServiceContract.Products;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rosentis.ServiceImplementation.Products
{
	public class ProductTechnicalApplicationService : IProductTechnicalService
	{
		#region Properties
		private UnitOfWork _unitOfWork = new UnitOfWork();
		#endregion Properties

		#region Ctors
		public ProductTechnicalApplicationService(RosentisContext context)
		{
		}
		#endregion Ctors

		#region Utilities
		#endregion Utilities

		#region Methods
		public ProductTechnicalDtos FindByProductId(long id)
		{
			return new ProductTechnicalDtos
			{
				ProductTechnicals = Mapper.Map<List<ProductTechnicalDto>>(_unitOfWork.productTechnicalRepository.Get(x => x.ProductId == id))
			};
		}
		public ProductTechnicalDto Save(ProductTechnicalDto dto)
		{
			var productTechnical = new ProductTechnical();

			if (dto.Id == 0)
			{
				productTechnical = Mapper.Map<ProductTechnical>(dto);
				var t = _unitOfWork.productTechnicalRepository.Get(x => x.ProductId == dto.ProductId && x.TechnicalId == dto.TechnicalId).Any();
				if (t)
				{
					dto.AddException(new ExceptionDto()
					{
						Message = "خطا",
						Title = "مشخصه تکراری می باشد"
					});
					return dto;
				}
				_unitOfWork.productTechnicalRepository.Insert(productTechnical);
				_unitOfWork.Save();
			}
			else
			{
				var t = _unitOfWork.productTechnicalRepository.Get(x => x.Id != dto.Id && x.ProductId == dto.ProductId && x.TechnicalId == dto.TechnicalId).Any();
				if (t)
				{
					dto.AddException(new ExceptionDto()
					{
						Message = "خطا",
						Title = "مشخصه تکراری می باشد"
					});
					return dto;
				}
				productTechnical = _unitOfWork.productTechnicalRepository.GetByID(dto.Id);
				
				productTechnical.Name = dto.Name;
				productTechnical.Description = dto.Description;
				productTechnical.IsChecked = dto.IsChecked;
				productTechnical.IsValid = dto.IsValid;
				productTechnical.TechnicalId = dto.TechnicalId;
				_unitOfWork.productTechnicalRepository.Update(productTechnical);
			}
			_unitOfWork.Save();

			dto.Id = productTechnical.Id;

			return dto;
		}
		public DtoResponse Remove(ProductTechnicalDto dto)
		{
			try
			{
				var ProductTechnical = _unitOfWork.productTechnicalRepository.GetFirst(x => x.Id == dto.Id);
				if (ProductTechnical != null && ProductTechnical.Id > 0)
				{
					_unitOfWork.productTechnicalRepository.Delete(dto.Id);
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
