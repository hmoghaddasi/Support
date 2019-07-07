using System;
using System.Collections.Generic;
using System.Text;

namespace Support.Domain.Model
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
