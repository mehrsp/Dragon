using System.Web.Http;
using Rosentis.DataContract.Base;
using Rosentis.DataContract.Users;
using Rosentis.ServiceContract.Users;
using Rosentis.DataContract.Users.Dtos;
using Microsoft.Ajax.Utilities;

namespace Rosentis.Api.Controllers.Users
{
    public class MembersController : ApiController
    {
        private IMemberService _memberApplicationService;

        public MembersController(IMemberService memberApplicationService)
        {
            _memberApplicationService = memberApplicationService;
        }
        public MemberDtos FindAll()
        {
            return _memberApplicationService.FindAll();
        }

        public MemberDto Save(Member dto)
        {
			return null;
        }
        public DtoResponse Remove(MemberDto dto)
        {
            return _memberApplicationService.Remove(dto);
        }
    }
}