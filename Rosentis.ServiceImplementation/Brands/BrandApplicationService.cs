using AutoMapper;
using Rosentis.DataContract.Base;
using Rosentis.DataContract.Base.Dtos;
using Rosentis.DataContract.Brands;
using Rosentis.DataContract.Brands.Dtos;
using Rosentis.DataContract.ExeptionModel;
using Rosentis.DomainModel.Brands;
using Rosentis.Persistance;
using Rosentis.Persistance.Facade;
using Rosentis.ServiceContract.Brands;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rosentis.ServiceImplementation.Products
{
	public class BrandApplicationService : IBrandService
	{
		#region Properties
		private UnitOfWork _unitOfWork = new UnitOfWork();
		#endregion Properties

		#region Ctors
		public BrandApplicationService(RosentisContext context) 
		{
		}
		#endregion Ctors

		#region Utilities
		//private BrandDtos FindByPredicate(Expression<Func<Brand, bool>> predicate = null)
		//{
		//	var list = new List<Brand>();

		//	_unitOfWork.BrandRepository.SetIncludes(x => x.CreatedBy);

		//	if (null == predicate)
		//		list = _unitOfWork.BrandRepository.Get().ToList;
		//	else
		//		list = _unitOfWork.BrandRepository.Get(predicate).ToList();

		//	//var docs = Mapper.Map<List<DocumentDto>>(list); !!!!!
		//	var productCategories = new List<BrandDto>();
		//	foreach (var pcategory in list)
		//	{
		//		productCategories.Add(Mapper.Map<BrandDto>(pcategory));
		//	}
		//	return new BrandDtos()
		//	{
		//		ProductCategories = productCategories
		//	};
		//}
		#endregion Utilities

		#region Methods
	public BrandDtos FindAll()
		{
			return new BrandDtos
			{
				Brands = Mapper.Map<List<BrandDto>>(_unitOfWork.BrandRepository.Get().ToList())
			};
		}
		public BrandDtos FindSpecials()
		{
			return new BrandDtos
			{
				Brands = Mapper.Map<List<BrandDto>>(_unitOfWork.BrandRepository.Get().OrderBy(x => x.Priority).Take(7).ToList())
			};
		}
		public DropBoxDtos FillDropBox()
		{
			return new DropBoxDtos
			{
				Items = Mapper.Map<List<DropBoxDto>>(_unitOfWork.BrandRepository.Get())
			};
		}

		public BrandDto FindById(long id)
		{
			var t = _unitOfWork.BrandRepository.GetFirst(x => x.Id == id);
			return Mapper.Map<BrandDto>(t);
		}
		public BrandDto FindByName(string name)
		{
			return Mapper.Map<BrandDto>(_unitOfWork.BrandRepository.GetFirst(x => x.Name == name));
		}
		public BrandDto Save(BrandDto dto)
		{
			var Brand = new Brand();

			if (dto.Id == 0)
			{
				var t = _unitOfWork.BrandRepository.GetFirst(x => x.Name == dto.Name);
				if (t != null) {
					dto.AddException(Mapper.Map<ExceptionDto>(_unitOfWork.Exception.GetFirst(x => x.Id == 4)));
					return dto; 
				}
				Brand = Mapper.Map<Brand>(dto);

				_unitOfWork.BrandRepository.Insert(Brand);
				_unitOfWork.Save();
			}
			else
			{
				Brand = _unitOfWork.BrandRepository.GetByID(dto.Id);
				
				Brand.Name = dto.Name;
				Brand.Description = dto.Description;
				_unitOfWork.BrandRepository.Update(Brand);
			}
			_unitOfWork.Save();

			dto.Id = Brand.Id;
			
			return dto; 
		}
		public DtoResponse Remove(BrandDto dto)
		{
			try
			{
				var Brand = _unitOfWork.BrandRepository.GetFirst(x => x.Id == dto.Id);
				if (Brand != null && Brand.Id > 0)
				{
				    //checked if haved product
				   var product = _unitOfWork.ProductRepository.GetFirst(x => x.BrandId == dto.Id);
				   if (product != null)
				   {
					  var dtoResponse = new DtoResponse();
					  dtoResponse.AddException(Mapper.Map<ExceptionDto>(_unitOfWork.Exception.GetFirst(x => x.Id == 5)));
					
				   return dtoResponse;
			       }
				   
					_unitOfWork.BrandRepository.Delete(dto.Id);
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
