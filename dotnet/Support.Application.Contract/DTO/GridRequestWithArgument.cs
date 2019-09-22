using System.Collections.Generic;
using Framework.Core.Filtering;

namespace Support.Application.Contract.DTO
{
    public class GridRequestWithArgument
    {
        public int Id { get; set; }
        public int Take { get; set; }
        public int Skip { get; set; }
        public string Filter { get; set; }
        public GridFilter FilterX { get; set; }
        public List<GridSort> Sort
        {
            get; set;
        }
    }
}
