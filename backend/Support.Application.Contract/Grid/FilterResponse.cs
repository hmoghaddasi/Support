using System.Collections.Generic;

namespace Support.Application.Contract.Grid
{
    public class FilterResponse<T>
    {
        public List<T> data { get; set; }
        public long total { get; set; }
        public int MinItem { get; set; }
        public FilterResponse(List<T> data, long total, int minItem = 0)
        {
            this.data = data;
            total = total;
            MinItem = minItem;

        }
    }
}
