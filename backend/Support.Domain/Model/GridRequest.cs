using System;
using System.Collections.Generic;
using System.Text;

namespace Support.Domain.Model
{
    public class GridRequest
    {
        public int Take { get; set; }
        public int Skip { get; set; }
        public string Filter { get; set; }
        public GridFilter FilterX { get; set; }
        public List<GridSort> Sort { get; set; }
    }
}
