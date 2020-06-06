using AutoMapper;
using Rosentis.DataContract.Products.Dtos;
using Rosentis.DataContract.Products;
using Rosentis.DomainModel.Products;
using Rosentis.Persistance;
using Rosentis.Persistance.Facade;
using Rosentis.ServiceContract.Products;
using System.Collections.Generic;
using System.Linq;
using Rosentis.DataContract.Base;
using Rosentis.DataContract.Base.Dtos;
using System;
using Rosentis.DataContract.ExeptionModel;

namespace Rosentis.ServiceImplementation.Products
{
	public class TechnicalApplicationService : GenericRepository<Technical>, ITechnicalService
	{
		#region Properties
		private UnitOfWork _unitOfWork = new UnitOfWork();
		#endregion Properties

		#region Ctors
		public TechnicalApplicationService(RosentisContext context) : base(context)
		{
		}

		public DropBoxDtos FillDropBox()
		{
			return new DropBoxDtos
			{
				Items = Mapper.Map<List<DropBoxDto>>(_unitOfWork.TechnicalRepository.Get(x=>x.ParentId == null))
			};
		}

		public DropBoxDtos FillDropBoxByTechnicalId(int id)
		{
			return new DropBoxDtos
			{
				Items = Mapper.Map<List<DropBoxDto>>(_unitOfWork.TechnicalRepository.Get(x=>x.ParentId == id))
			};
		}

		public TechnicalDtos FindAll()
		{
			return new TechnicalDtos
			{
				Technicals = Mapper.Map<List<TechnicalDto>>(_unitOfWork.TechnicalRepository.Get(x => x.ParentId == null).ToList())
			};
		}

		public TechnicalDto FindById(int id)
		{
			return Mapper.Map<TechnicalDto>(_unitOfWork.TechnicalRepository.GetFirst(x => x.Id == id));
		}
		
		public TechnicalDtos FindByTechnicalId(int id)
		{
			return new TechnicalDtos
			{
				Technicals = Mapper.Map<List<TechnicalDto>>(_unitOfWork.TechnicalRepository.Get(x=>x.ParentId == id).ToList())
			};
		}

		public DtoResponse Remove(TechnicalDto dto)
		{
			try
			{
				var DtoResponse = new DtoResponse();
                
				//check if have product
				var checkProduct = _unitOfWork.productTechnicalRepository.Get(x => x.TechnicalId == dto.Id).Any();
				if (checkProduct)
				{
					DtoResponse.AddException(new ExceptionDto()
					{
						Message = "خطا",
						Title = "از این مشخصه در محصولات استفاده شده است مجاز به حذف نمی باشید"
					});
					return DtoResponse;
				}

				//check childs for if defined in product
				var checkChilds = _unitOfWork.TechnicalRepository.Get(x=>x.ParentId == dto.Id).ToList();
				if (checkChilds.Count != 0) {
					foreach (var rec in checkChilds) {
						var checkPr = _unitOfWork.productTechnicalRepository.Get(x => x.TechnicalId == rec.Id).Any();
						if (checkPr)
						{
							DtoResponse.AddException(new ExceptionDto()
							{
								Message = "خطا",
								Title ="در محصولات استفاده شده است. مجاز به حذف نمی باشید. " + rec.Title.ToString() + " از مشخصه"
							});
							return DtoResponse;
						}
					}
				}

				//remove product category technicals of receiving object 
				foreach (var rec in _unitOfWork.ProductCategoryTechnicalRepository.Get(x => x.TechnicalId == dto.Id).ToList())
				{
					_unitOfWork.ProductCategoryTechnicalRepository.Delete(rec.Id);

				}

				//remove childs
				foreach (var rec in _unitOfWork.TechnicalRepository.Get(x=>x.ParentId == dto.Id).ToList())
				{
					_unitOfWork.TechnicalRepository.Delete(rec.Id);
				}

				//remove technical
				_unitOfWork.TechnicalRepository.Delete(dto.Id);
				_unitOfWork.Save();
				return new DtoResponse();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public TechnicalDto Save(TechnicalDto dto)
		{
			var technical = new Technical();

			if (dto.Id == 0)
			{
				var t = _unitOfWork.TechnicalRepository.GetFirst(x => x.ParentId == dto.ParentId && x.Title == dto.Title);
				if (t != null)
				{
					dto.AddException(new ExceptionDto()
					{
						Message = "خطا",
						Title = "نام مشخصه تکراری می باشد"
					});
					return dto;
				}
				technical = Mapper.Map<Technical>(dto);

				_unitOfWork.TechnicalRepository.Insert(technical);
				_unitOfWork.Save();
			}
			else
			{
				technical = _unitOfWork.TechnicalRepository.GetByID(dto.Id);
				var checkTitle = _unitOfWork.TechnicalRepository.Get(x => x.Title == dto.Title).FirstOrDefault();
				if (checkTitle != null && checkTitle.Id != dto.Id)
				{
					dto.AddException(new ExceptionDto()
					{
						Message = "خطا",
						Title = "نام مشخصه تکراری می باشد"
					});
					return dto;
				}
				technical.Title = dto.Title;
				_unitOfWork.TechnicalRepository.Update(technical);
			}
			_unitOfWork.Save();

			dto.Id = technical.Id;
			dto.ParentId = technical.ParentId;
			return dto;
		}
		#endregion Ctors
	}
}
