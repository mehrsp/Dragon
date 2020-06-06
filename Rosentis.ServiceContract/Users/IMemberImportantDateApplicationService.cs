using Rosentis.DataContract.Base;
using Rosentis.DataContract.Users;

namespace Rosentis.ServiceContract.Users
{
    public interface IMemberImportantDateApplicationService
    {
        MemberImportantDateDto Save(MemberImportantDateDto dto);
        DtoResponse Remove(MemberImportantDateDto dto);
        MemberImportantDateDtos FindAll();
        MemberImportantDateDto Find(long id);
    }
}
