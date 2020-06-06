using Rosentis.DataContract.Visits;
using System;
using System.Collections.Generic;

namespace Rosentis.ServiceContract.Visits
{
    public interface IVisitorApplicationService
    {
        VisitorDto Save(VisitorDto dto);
        bool Remove(VisitorDto dto);
        IList<VisitorDto> FindAll();
        VisitorDto Find(Guid id);
    }
}
