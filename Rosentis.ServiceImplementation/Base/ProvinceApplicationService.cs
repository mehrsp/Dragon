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
		public class ProvinceApplicationService : IProvinceService
		{

		#region Properties
		private UnitOfWork _unitOfWork = new UnitOfWork();
		#endregion Properties

		#region Ctors
		public ProvinceApplicationService(RosentisContext context) 
			{
			}
        #endregion Ctors

		#region Method
		public ProvinceDtos FindAll()
		{
				var dtos = new ProvinceDtos();
		     	var t = _unitOfWork.ProvinceRepository.Get();
			   dtos.Provinces = AutoMapper.Mapper.Map<List<ProvinceDto>>(t);
				return dtos;
		}
		public DropBoxDtos FillDropBox()
		{
			return new DropBoxDtos
			{
				Items = AutoMapper.Mapper.Map<List<DropBoxDto>>(_unitOfWork.ProvinceRepository.Get())
			};
		}
		#endregion

	}
}
