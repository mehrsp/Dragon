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
	public class ProductCatalogApplicationService :  IProductCatalogService
	{
		#region Properties
		private UnitOfWork _unitOfWork = new UnitOfWork();
		#endregion

		#region Ctors
		public ProductCatalogApplicationService(RosentisContext context) 
		{
		}
		#endregion

		#region Utilities
		#endregion

		#region Methods
		public ProductCatalogDtos FindByProductId(long id)
		{
			//_unitOfWork.ProductCatalogRepository.SetIncludes(x => x.Document);
			return new ProductCatalogDtos
			{
				ProductCatalogs = Mapper.Map<List<ProductCatalogDto>>(_unitOfWork.ProductCatalogRepository.Get(x => x.ProductId == id))
			};
		}
		public ProductCatalogDto Save(ProductCatalogDto dto)
		{
			var ProductCatalog = new ProductCatalog();
			ProductCatalog = Mapper.Map<ProductCatalog>(dto);
			ProductCatalog.CreatedDate = DateTime.Now;

			_unitOfWork.ProductCatalogRepository.Insert(ProductCatalog);
			_unitOfWork.Save();

			dto.Id = ProductCatalog.Id;

			return dto;
		}
		public DtoResponse Remove(ProductCatalogDto dto)
		{
			try
			{
				var ProductCatalog = _unitOfWork.ProductCatalogRepository.GetFirst(x => x.Id == dto.Id);
				if (ProductCatalog != null && ProductCatalog.Id > 0)
				{
					_unitOfWork.ProductCatalogRepository.Delete(dto.Id);
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
