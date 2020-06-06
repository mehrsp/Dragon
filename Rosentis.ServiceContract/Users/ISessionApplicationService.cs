using System;
using System.Collections.Generic;
using Rosentis.DataContract.Users;

namespace Rosentis.ServiceContract.Users
{
    public interface ISessionApplicationService
    {
        SessionDto Save(SessionDto dto);
        bool Remove(SessionDto dtp);
        IList<SessionDto> FindAll();
        SessionDto Find(Guid id);
    }
}
