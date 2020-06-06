﻿
using System.Collections.Generic;

namespace Rosentis.Core
{
    /// <summary>
    /// Paged list interface
    /// </summary>
    public interface IPagedList<T> : IPageable, IList<T>
    {
        // codehint: sm-delete (members of IPageable now)
    }
}
