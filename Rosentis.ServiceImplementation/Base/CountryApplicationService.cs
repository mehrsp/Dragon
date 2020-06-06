using AutoMapper;
using Rosentis.DataContract.Base;
using Rosentis.DataContract.Base.Dtos;
using Rosentis.DataContract.Brands;
using Rosentis.DataContract.Brands.Dtos;
using Rosentis.DataContract.ExeptionModel;
using Rosentis.DataContract.Info.Address;
using Rosentis.DataContract.Info.Address.Dtos;
using Rosentis.DomainModel.Brands;
using Rosentis.Persistance;
using Rosentis.Persistance.Facade;
using Rosentis.ServiceContract.Brands;
using Rosentis.ServiceContract.Info.Address;
using Rosentis.ServiceImplementation.Base.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Rosentis.ServiceImplementation.Base
{
	public class CountryApplicationService : ICountryService
	{

		#region Properties
		private UnitOfWork _unitOfWork = new UnitOfWork();
		#endregion Properties

		#region Ctors
		public CountryApplicationService(RosentisContext context) 
		{
		}
		#endregion Ctors

		#region Method
		public CountryDtos FindAll()
		{
			return null;
			//return new CountryDtos() { Cities =  AutoMapper.Mapper.Map<List<CountryDto>>(_unitOfWork.CountryRepository.Get()) };
		}
		public DropBoxDtos FillDropBox()
		{
			return new DropBoxDtos
			{
				Items = _unitOfWork.countryRepository.Get(null).Select(CountryMapper.MapForDropBox).ToList()
			};
		}
		public CountryDto FindById(int id)
		{
			return _unitOfWork.countryRepository.Get(x => x.Id == id).Select(CountryMapper.MapToDto).FirstOrDefault();
		}
		public DropBoxDtos FindByProvinceId(int provinceId)
		{
			return null;
			//return new DropBoxDtos() { Items = AutoMapper.Mapper.Map<List<DropBoxDto>>(_unitOfWork.CountryRepository.Get(x => x.ProvinceId == provinceId)) };
		}
		#endregion

	}
}
