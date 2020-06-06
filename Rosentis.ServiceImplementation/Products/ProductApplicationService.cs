using AutoMapper;
using Rosentis.DataContract.Products;
using Rosentis.DataContract.Products.Dtos;
using Rosentis.DataContract.ExeptionModel;
using Rosentis.DomainModel.Products;
using Rosentis.Persistance;
using Rosentis.ServiceContract.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using Rosentis.Persistance.Facade;
using Rosentis.Core;
using Rosentis.Core.Filtering;
//using LabXand.Core;

namespace Rosentis.ServiceImplementation.Products
{
	public class ProductApplicationService : IProductService
	{
		#region Properties
		private UnitOfWork _unitOfWork = new UnitOfWork();
		private readonly IProductCategoryService _productCagtegoryService;
		#endregion Properties

		#region Ctors
		public ProductApplicationService(RosentisContext context, IProductCategoryService productCagtegoryService) 
		{
			_productCagtegoryService = productCagtegoryService;
		}
		#endregion Ctors

		#region Utilities
		//private ProductDtos FindByPredicate(Expression<Func<Product, bool>> predicate = null)
		//{
		//	var list = new List<Product>();

		//	_unitOfWork.ProductRepository.SetIncludes(x => x.CreatedBy);

		//	if (null == predicate)
		//		list = _unitOfWork.ProductRepository.Get().ToList;
		//	else
		//		list = _unitOfWork.ProductRepository.Get(predicate).ToList();

		//	//var docs = Mapper.Map<List<DocumentDto>>(list); !!!!!
		//	var productCategories = new List<ProductDto>();
		//	foreach (var pcategory in list)
		//	{
		//		productCategories.Add(Mapper.Map<ProductDto>(pcategory));
		//	}
		//	return new ProductDtos()
		//	{
		//		ProductCategories = productCategories
		//	};
		//}
		#endregion Utilities

		#region Methods
		public ProductDtos FindAll(SpecificationOfDataList<ProductDto> request)
		{
			_unitOfWork.ProductRepository.SetIncludes(x => x.Supplier);
			var dtos = new ProductDtos();
			request.FilterSpecifications.Add(new FilterSpecification<ProductDto>()
			{
				FilterOperation = FilterOperations.Equal,
				PropertyName = "IsRemoved",
				FilterValue = false
			});
			var test = request.GetCriteria();
			return dtos;
		}
		public FilterResponse<ProductDto> FindAllFiltered(GridRequest request, string ids)
		{
			if (ids != "") {
				ids = "Select * from prd.Products where ProductCategoryId in(" + ids + ")";
			}			
			var t = _unitOfWork.ProductRepository.GetFilteredListForGrid(x=>x.ParentId == null , request, ids);
			var test = t.Data.ToList();
			var productList = Mapper.Map < List<ProductDto>>(test);

			return new FilterResponse<ProductDto>(productList, productList.Count);
		}
		public decimal FindPagesNumber(int categoryId)
		{
			var productCount = new List<Product>();
			productCount = _unitOfWork.ProductRepository.Get(x=>x.ProductCategoryId == categoryId).ToList();
			return Math.Ceiling((decimal)productCount.Count() / (decimal)9);
		}
		public ProductDto FindById(long id)
		{
			var t = _unitOfWork.ProductRepository.Get(x => x.ParentId == null && x.Id == id).FirstOrDefault();
			var product = Mapper.Map<ProductDto>(_unitOfWork.ProductRepository.Get(x => x.ParentId == null && x.Id == id).FirstOrDefault());
			
			//add categories of product to list 
			product.Categories = new List<ProductCategoryDto>();
			product.Categories.Add(product.ProductCategory);
			if (product.ProductCategory.ParentId != null)
			{
				product.Categories = _fillCategories(product.ProductCategory, new List<ProductCategoryDto>());
			}
			return product;
		}
		public List<ProductCategoryDto> FindCategoriesWithParent(ProductCategoryDto productCategory)
		{
			var list = new List<ProductCategoryDto>();

			//add categories of product to list 
			if (productCategory.ParentId != null)
			{
				list = _fillCategories(productCategory, new List<ProductCategoryDto>());
			}
			return list;
		}
		public ProductDto FindByChildId(long id)
		{
			return Mapper.Map<ProductDto>(_unitOfWork.ProductRepository.Get(x => x.Id == id).FirstOrDefault());
		}
		public double CheckQuantity(long id)
		{
			return _unitOfWork.ProductRepository.Get(x => x.Id == id).FirstOrDefault().Quantity;
		}
		public ProductDto Save(ProductDto dto)
		{
			var product = new Product();
			var t = _unitOfWork.ProductRepository.GetFirst(x => x.ProductCategoryId == dto.ProductCategoryId && x.Name == dto.Name);
			if (dto.Id == 0 && t != null)
			{
				dto.AddException(Mapper.Map<ExceptionDto>(_unitOfWork.Exception.GetFirst(x => x.Id == 7)));
				return dto;
			}
			if (dto.Id == 0)
			{				
				product = Mapper.Map<Product>(dto);

				_unitOfWork.ProductRepository.Insert(product);
				_unitOfWork.Save();


			}
			else
			{
				product = _unitOfWork.ProductRepository.GetByID(dto.Id);
	
				product.BrandId = dto.BrandId;
				product.Description = dto.Description;
				product.Quantity = dto.Quantity;
				product.Name = dto.Name;
				product.Description = dto.Description;
				product.LatestPriceModified = DateTime.Now;
				product.Price = dto.Price;
				product.ProductCategoryId = dto.ProductCategoryId;
				product.SupplierId = dto.SupplierId;
				_unitOfWork.ProductRepository.Update(product);
			}
			_unitOfWork.Save();

			return dto;
		}
		public ProductDtos FindByProductCategoryId(long id)
		{
			_unitOfWork.ProductRepository.SetIncludes(x => x.Supplier);
			return new ProductDtos
			{
				Products = Mapper.Map<List<ProductDto>>(_unitOfWork.ProductRepository.Get(x => x.ProductCategoryId == id))
			};
		}

		public ProductDtos FindPopulars()
		{
			return new ProductDtos
			{
				Products = Mapper.Map<List<ProductDto>>(_unitOfWork.ProductRepository.Get(x=>x.ParentId == null).OrderBy(x => x.Ranking).Take(10))
			};
		}

		public ProductDtos FindMostSells()
		{
			return new ProductDtos
			{
				Products = Mapper.Map<List<ProductDto>>(_unitOfWork.ProductRepository.Get(x => x.ParentId == null).OrderBy(x => x.SoldCount).Take(10))
			};
		}

		public ProductDtos FindNews()
		{
			return new ProductDtos
			{
				Products = Mapper.Map<List<ProductDto>>(_unitOfWork.ProductRepository.Get(x => x.ParentId == null).OrderByDescending(x =>x.CreatedDate).Take(10))
			};
		}
		#endregion Methods

		#region Functions
		private List<ProductCategoryDto> _fillCategories(ProductCategoryDto productCategory, List<ProductCategoryDto> list)
		{
			ProductCategoryDto category = Mapper.Map<ProductCategoryDto>(_productCagtegoryService.FindById(productCategory.ParentId));
			list.Add(category);
			if (category.ParentId != null)
			{
				return list = _fillCategories(category, list);
			}
			else
			{
				return list;
			}
		}
		public decimal MaxPrice(SpecificationOfDataList<ProductDto> request)
		{
			throw new NotImplementedException();
		}

		public decimal MinPrice(SpecificationOfDataList<ProductDto> request)
		{
			throw new NotImplementedException();
		}
		#endregion
	}
}
