using Rosentis.DataContract.Visits;
using System;
using System.Collections.Generic;

namespace Rosentis.ServiceContract.Visits
{
    public interface IPageUrlApplicationService
    {
        PageUrlDto Save(PageUrlDto dto);
        bool Remove(PageUrlDto dto);
        IList<PageUrlDto> FindAll();
        PageUrlDto Find(Guid id);
    }
}
