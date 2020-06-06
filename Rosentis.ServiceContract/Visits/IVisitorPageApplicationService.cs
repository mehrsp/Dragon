using Rosentis.DataContract.Visits;
using System;
using System.Collections.Generic;

namespace Rosentis.ServiceContract.Visits
{
    public interface IVisitorPageApplicationService
    {
        VisitorPageDto Save(VisitorPageDto dto);
        bool Remove(VisitorPageDto dto);
        IList<VisitorPageDto> FindAll();
        VisitorPageDto Find(Guid id);
    }
}
