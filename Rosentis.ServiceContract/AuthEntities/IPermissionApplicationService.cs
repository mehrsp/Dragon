using Rosentis.DataContract.AuthEntities;

namespace Rosentis.ServiceContract.AuthEntities
{
    public interface IPermissionApplicationService
    {
        PermissionDto Save(PermissionDto dto);
        bool Remove(PermissionDto dto);
        PermissionDtos FindAll();
        PermissionDto Find(long id);
    }
}
