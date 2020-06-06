using System.Linq;
using Rosentis.DataContract.AuthEntities;
using Rosentis.DomainModel.AuthEntities;
using Rosentis.ServiceContract.AuthEntities;
using Rosentis.ServiceImplementation.AuthEntities.Mapper;
using Rosentis.Persistance.Core.AuthEntities;
using Rosentis.Persistance;
using Rosentis.DistributedServices;

namespace Rosentis.ServiceImplementation.AuthEntities
{
    public class PermissionApplicationService:IPermissionApplicationService
    {
		#region Propertises
		private readonly IEntityMapper<Permission, PermissionDto> _mapper;
		private readonly IPermissionRepository _repository;
		private UnitOfWork _unitOfWork = new UnitOfWork();
		#endregion

		#region Ctor
		public PermissionApplicationService(IEntityMapper<Permission, PermissionDto> mapper, IPermissionRepository repository)
		{
			_mapper = mapper;
			_repository = repository;
		}
		#endregion


		public PermissionDto Find(long id)
		{
			return _unitOfWork.PermissionRepository.Get(x=> x.Id == id).Select(_mapper.MapTo).FirstOrDefault();
		}

		public PermissionDtos FindAll()
		{
			return new PermissionDtos()
			{
				Permissions = _unitOfWork.PermissionRepository.Get().Select(_mapper.MapTo).ToList()
			};
		}

		public PermissionDto Save(PermissionDto dto)
		{
			var model = _unitOfWork.PermissionRepository.Insert(_mapper.CreateFrom(dto));
			return _unitOfWork.PermissionRepository.Get(x => x.Id == model.Id).Select(_mapper.MapTo).FirstOrDefault();
		}

		public bool Remove(PermissionDto dto)
		{
			_unitOfWork.PermissionRepository.Delete(dto.Id);
			return true;
		}
	}
}
