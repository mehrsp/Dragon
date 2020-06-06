using System.Collections.Generic;

namespace Rosentis.Core.Filtering
{
    public class FilterResponse<T>
    {
        public List<T> Data { get; set; }
        public long Count { get; set; }
        public int MinItem { get; set; }
        public FilterResponse(List<T> data, long count, int minItem=0)
        {
            Data = data;
            Count = count;
            MinItem = minItem;

        }
    }
}
