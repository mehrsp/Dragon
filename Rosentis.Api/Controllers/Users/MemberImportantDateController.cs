using System.Web.Http;
using Rosentis.DataContract.Base;
using Rosentis.DataContract.Users;
using Rosentis.ServiceContract.Users;

namespace Rosentis.Api.Controllers.Users
{
    public class MemberImportantDatesController : ApiController
    {
        private IMemberImportantDateApplicationService _MemberImportantDateApplicationService;

        public MemberImportantDatesController(IMemberImportantDateApplicationService MemberImportantDateApplicationService)
        {
            _MemberImportantDateApplicationService = MemberImportantDateApplicationService;
        }
        public MemberImportantDateDtos FindAll()
        {
            return _MemberImportantDateApplicationService.FindAll();
        }

        public MemberImportantDateDto Save(MemberImportantDateDto dto)
        {
            return _MemberImportantDateApplicationService.Save(dto);
        }
        public DtoResponse Remove(MemberImportantDateDto dto)
        {
            return _MemberImportantDateApplicationService.Remove(dto);
        }
    }
}