using System.Collections.Generic;

namespace Rosentis.Core.Filtering
{
    public class GridRequest
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public GridFilter Filter { get; set; }
        public List<GridSort> Sort { get; set; }
    }
}
