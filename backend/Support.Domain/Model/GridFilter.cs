using System;
using System.Collections.Generic;
using System.Text;

namespace Support.Domain.Model
{
    public class GridFilter
    {
        public string Operator { get; set; }
        public string Field { get; set; }
        public string Value { get; set; }
        public string Logic { get; set; }
        public object perdict { get; set; }
        public List<GridFilter> Filters { get; set; }
    }
}
