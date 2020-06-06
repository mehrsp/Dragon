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
using System.Linq;

namespace Rosentis.ServiceImplementation.Products
{
	public class ProductCategoryApplicationService : IProductCategoryService
	{
		#region Properties
		private UnitOfWork _unitOfWork = new UnitOfWork();
		#endregion Properties

		#region Ctors
		public ProductCategoryApplicationService(RosentisContext context)
		{
		}
		#endregion Ctors

		#region Utilities
		//private ProductCategoryDtos FindByPredicate(Expression<Func<ProductCategory, bool>> predicate = null)
		//{
		//	var list = new List<ProductCategory>();

		//	_unitOfWork.ProductCategoryRepository.SetIncludes(x => x.CreatedBy);

		//	if (null == predicate)
		//		list = _unitOfWork.ProductCategoryRepository.Get().ToList;
		//	else
		//		list = _unitOfWork.ProductCategoryRepository.Get(predicate).ToList();

		//	//var docs = Mapper.Map<List<DocumentDto>>(list); !!!!!
		//	var productCategories = new List<ProductCategoryDto>();
		//	foreach (var pcategory in list)
		//	{
		//		productCategories.Add(Mapper.Map<ProductCategoryDto>(pcategory));
		//	}
		//	return new ProductCategoryDtos()
		//	{
		//		ProductCategories = productCategories
		//	};
		//}
		#endregion Utilities

		#region Methods

		public ProductCategoryDataDtos FindAll()
		{
			var dto = new ProductCategoryDataDtos();
			var t = _unitOfWork.ProductCategoryRepository.Get(x=>x.ParentId == null);
			var dtos = Mapper.Map<List<ProductCategoryDto>>(t);
			var ProductCategorysDataDtos = new List<ProductCategoryDataDto>();
			foreach (var item in dtos)
			{
				var model = new ProductCategoryDataDto
				{
					model = item,
					data = item.Name,
					label = item.Name
				};
				ProductCategorysDataDtos.Add(model);
				_fillChildrens(item, model);
			}

			dto.data = ProductCategorysDataDtos;
			return dto;
		}
		private void _fillChildrens(ProductCategoryDto item, ProductCategoryDataDto model)
		{
			model.children = new List<ProductCategoryDataDto>();
			
			foreach (var child in item.Children)
			{
				var t = _unitOfWork.ProductCategoryRepository.Get(x => x.ParentId == child.Id);
				child.Children = Mapper.Map<List<ProductCategoryDto>>(t);
				var childModel = new ProductCategoryDataDto();
				childModel.data = child.Name;
				childModel.label = child.Name;
				childModel.model = child;
				model.children.Add(childModel);
				if (child.Children.Count > 0)
				{
					_fillChildrens(child, childModel);
				}
			}
		}
		public DropBoxDtos FillDropBox()
		{
			return new DropBoxDtos
			{
				Items = Mapper.Map<List<DropBoxDto>>(_unitOfWork.ProductCategoryRepository.Get(x => x.ParentId != null && x.Children.Count == 0))
			};
		}
		public ProductCategoryDto FindById(int? id)
		{
			var pCategory = Mapper.Map<ProductCategoryDto>(_unitOfWork.ProductCategoryRepository.Get(x => x.Id == id).FirstOrDefault());
			//doc.CreatedBy = new UserDto() { DisplayName = doc.CreatedBy?.DisplayName ?? "" };
			return pCategory;
		}
		public ProductCategoryDataDto Save(ProductCategoryDto dto)
		{
			var productCategory = new ProductCategory();

			if (dto.Id == 0)
			{
				var t = _unitOfWork.ProductCategoryRepository.GetFirst(x =>x.ParentId == dto.ParentId && x.Name == dto.Name);
				if (t != null) {
					dto.AddException(Mapper.Map<ExceptionDto>(_unitOfWork.Exception.GetFirst(x => x.Id == 1)));
					return new ProductCategoryDataDto
					{
						model = dto
					}; 
				}
				var checkIsProductAdd = _unitOfWork.ProductRepository.Get(x => x.ProductCategoryId == dto.ParentId).Any();
				if (checkIsProductAdd)
				{
					dto.AddException(new ExceptionDto()
					{
						Message = "خطا",
						Title = "برای دسته بندی انتخاب شده ، محصول تعریف شده است. مجاز به ایجاد زیرمجموعه جدید نمی باشید."
					});
					return new ProductCategoryDataDto
					{
						model = dto
					};
				}
				var checkIsTechnicalAdd = _unitOfWork.ProductCategoryTechnicalRepository.Get(x => x.ProductCategoryId == dto.ParentId).Any();
				if (checkIsTechnicalAdd)
				{
					dto.AddException(new ExceptionDto()
					{
						Message = "خطا",
						Title = "برای دسته بندی انتخاب شده ، مشخصه تعریف شده است. مجاز به ایجاد زیرمجموعه جدید نمی باشید."
					});
					return new ProductCategoryDataDto
					{
						model = dto
					};
				}
				productCategory = Mapper.Map<ProductCategory>(dto);
				productCategory.CreatedDate = DateTime.Now;

				_unitOfWork.ProductCategoryRepository.Insert(productCategory);
				_unitOfWork.Save();
			}
			else
			{
				_unitOfWork.ProductCategoryRepository.SetIncludes(x => x.Products);
				productCategory = _unitOfWork.ProductCategoryRepository.GetByID(dto.Id);

				productCategory.ModifiedDate = DateTime.Now;
				productCategory.Name = dto.Name;
				_unitOfWork.ProductCategoryRepository.Update(productCategory);
			}
			_unitOfWork.Save();

			dto.Id = productCategory.Id;
			
			return new ProductCategoryDataDto
			{
				model = dto,
				data = dto.Name,
				label = dto.Name
			}; 
		}

		public DtoResponse Remove(ProductCategoryDto dto)
		{
			try
			{
				var pCategory = _unitOfWork.ProductCategoryRepository.GetFirst(x => x.Id == dto.Id);
				if (pCategory != null && pCategory.Id > 0)
				{

					//checked if haved child
					if (pCategory.Children.Count > 0)
				    {
					var dtoResponse = new DtoResponse();
					dtoResponse.AddException(Mapper.Map<ExceptionDto>(_unitOfWork.Exception.GetFirst(x => x.Id == 3)));


					return dtoResponse;
				    }

				    //checked if haved product
				   var product = _unitOfWork.ProductRepository.Get(x => x.ProductCategoryId == dto.Id).Any();
				   if (product)
				   {
					  var dtoResponse = new DtoResponse();
					  dtoResponse.AddException(Mapper.Map<ExceptionDto>(_unitOfWork.Exception.GetFirst(x => x.Id == 2)));
					
				   return dtoResponse;
			       }
					_unitOfWork.ProductCategoryRepository.Delete(dto.Id);
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
