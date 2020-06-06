using System.Web.Http;
using Rosentis.DataContract.AuthEntities;
using Rosentis.ServiceContract.AuthEntities;

namespace Rosentis.Api.Controllers.AuthEntities
{
    public class PermissionsController : ApiController
    {
        private IPermissionApplicationService _PermissionApplicationService;

        public PermissionsController(IPermissionApplicationService PermissionApplicationService)
        {
            _PermissionApplicationService = PermissionApplicationService;
        }
        public PermissionDtos FindAll()
        {
            return _PermissionApplicationService.FindAll();
        }

        public PermissionDto Save(PermissionDto dto)
        {
            return _PermissionApplicationService.Save(dto);
        }
        public bool Remove(PermissionDto dto)
        {
            return _PermissionApplicationService.Remove(dto);
        }
    }
}