using AutoMapper;
using Rosentis.DataContract.Base;
using Rosentis.DataContract.Base.Dtos;
using Rosentis.DataContract.ExeptionModel;
using Rosentis.DataContract.Products;
using Rosentis.DomainModel.Products;
using Rosentis.Persistance;
using Rosentis.Persistance.Facade;
using Rosentis.ServiceContract.Products;
using System;
using System.Collections.Generic;
using Rosentis.DataContract.Products.Dtos;
using System.Linq;

namespace Rosentis.ServiceImplementation.Products
{
	public class ProductCategoryTechnicalApplicationService : IProductCategoryTechnicalService
	{
		#region Properties
		private UnitOfWork _unitOfWork = new UnitOfWork();
		#endregion Properties

		#region Ctors
		public ProductCategoryTechnicalApplicationService(RosentisContext context)
		{
		}
		#endregion Ctors

		#region Utilities

		#endregion Utilities

		#region Methods

		public ProductCategoryTechnicalDto FindById(int id)
		{
			return Mapper.Map<ProductCategoryTechnicalDto>(_unitOfWork.ProductCategoryTechnicalRepository.GetFirst(x => x.Id == id));
		}

		public ProductCategoryTechnicalDtos FindByProductCategoryId(int id)
		{
			return new ProductCategoryTechnicalDtos()
			{
				ProductCategoryTechnicals = Mapper.Map<List<ProductCategoryTechnicalDto>>(_unitOfWork.ProductCategoryTechnicalRepository.Get(x => x.ProductCategoryId == id).ToList())
			};
		}

		public DtoResponse Remove(ProductCategoryTechnicalDto dto)
		{
			try
			{
				_unitOfWork.ProductCategoryTechnicalRepository.Delete(dto.Id);
				_unitOfWork.Save();
				return new DtoResponse();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public ProductCategoryTechnicalDto Save(ProductCategoryTechnicalDto dto)
		{
			var checkIsCategoryChild = _unitOfWork.ProductCategoryRepository.Get(x => x.ParentId == dto.ProductCategoryId).Any();
			if (checkIsCategoryChild)
			{
				dto.AddException(new ExceptionDto()
				{
					Message = "خطا",
					Title = "دسته بندی انتخابی دارای زیرمجموعه است. مجاز به ثبت مشخصه برای این دسته بندی نمی باشید."
				});
				return dto;
			}
			if (dto.TechnicalId != null) {
				var chekIsTechnical = _unitOfWork.ProductCategoryTechnicalRepository.Get(x => x.ProductCategoryId == dto.ProductCategoryId && x.TechnicalId == dto.TechnicalId).Any();
				if (chekIsTechnical)
				{
					dto.AddException(new ExceptionDto()
					{
						Message = "خطا",
						Title = "مشخصه انتخابی برای این دسته بندی تکراری است "
					});
					return dto;
				}
			}
			if (dto.BrandId != null)
			{
				var chekIsBrand = _unitOfWork.ProductCategoryTechnicalRepository.Get(x => x.ProductCategoryId == dto.ProductCategoryId && x.BrandId == dto.BrandId).Any();
				if (chekIsBrand)
				{
					dto.AddException(new ExceptionDto()
					{
						Message = "خطا",
						Title = "برند انتخابی برای این دسته بندی تکراری است "
					});
					return dto;
				}
			}
			var ProductCategoryTechnical = Mapper.Map<ProductCategoryTechnical>(dto);

			_unitOfWork.ProductCategoryTechnicalRepository.Insert(ProductCategoryTechnical);
			_unitOfWork.Save();
			return dto;
		}
		#endregion Methods
	}
}
