using System.Web.Http;
using Rosentis.DataContract.Users;
using Rosentis.ServiceContract.Users;

namespace Rosentis.Api.Controllers
{
    public class RolesController : ApiController
    {
        private IRoleApplicationService _roleApplicationService;
        public RolesController(IRoleApplicationService roleApplicationService)
        {
            _roleApplicationService = roleApplicationService;
        }
        [HttpPost]
        public RoleDtos FindAll()
        {
            var items = _roleApplicationService.FindAll();
            return items;
        }
    }
}
