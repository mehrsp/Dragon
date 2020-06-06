using Rosentis.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic;

namespace Rosentis.Core
{
    public static class SortItemHelper
    {
        public static IQueryable<T> GetQueryable<T>(this SortItem sortItem, IQueryable<T> source) where T : class
        {
            Guard.ArgumentNotNull(source, "source");
            return sortItem == null
                ? null
                : source.OrderBy(sortItem.Direction == SortDirection.Descending
                    ? string.Format("{0} DESC", sortItem.SortFiledsSelector)
                    : sortItem.SortFiledsSelector);
        }

        public static IQueryable<T> GetQueryable<T>(List<SortItem> sortItems, IQueryable<T> source) where T : class
        {
            Guard.ArgumentNotNull(source, "source");
            if (sortItems == null || sortItems.Count == 0)
                return source;

            sortItems.ForEach(s => source = s.GetQueryable(source));
            return source;
        }
    }
}
