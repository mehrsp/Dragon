using AutoMapper;
using Rosentis.DataContract.Base;
using Rosentis.DataContract.Base.Dtos;
using Rosentis.DataContract.Info.Address;
using Rosentis.DataContract.Info.Address.Dtos;
using Rosentis.DomainModel.Base;
using Rosentis.Persistance;
using Rosentis.Persistance.Facade;
using Rosentis.ServiceContract.Info.Address;
using System.Collections.Generic;

namespace Rosentis.ServiceImplementation.Base
{
	public class CityApplicationService : ICityService
	{

		#region Properties
		private UnitOfWork _unitOfWork = new UnitOfWork();
		#endregion Properties

		#region Ctors
		public CityApplicationService(RosentisContext context) 
		{
		}
		#endregion Ctors

		#region Method
		public CityDtos FindAll()
		{
			return null;
			//return new CityDtos() { Cities =  AutoMapper.Mapper.Map<List<CityDto>>(_unitOfWork.CityRepository.Get()) };
		}
		public DropBoxDtos FillDropBox()
		{
			//return new DropBoxDtos
			//{
			//	Items = AutoMapper.Mapper.Map<List<DropBoxDto>>(_unitOfWork.CityRepository.Get())
			//};
			return null;
		}
		public DropBoxDtos FindByProvinceId(int provinceId)
		{
			return new DropBoxDtos() { Items = AutoMapper.Mapper.Map<List<DropBoxDto>>(_unitOfWork.CityRepository.Get(x => x.ProvinceId == provinceId)) };
		}
		#endregion

	}
}
