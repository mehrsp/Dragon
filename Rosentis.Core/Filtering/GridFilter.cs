using System.Collections.Generic;

namespace Rosentis.Core.Filtering
{
    public class GridFilter
    {
        public string Operator { get; set; }
        public string Field { get; set; }
        public object Value { get; set; }
        public string Logic { get; set; }
        public object perdict { get; set; }
        public List<GridFilter> Filters { get; set; }
    }
}