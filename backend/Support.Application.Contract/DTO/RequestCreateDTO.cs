using System;
using System.Collections.Generic;
using System.Text;

namespace Support.Application.Contract.DTO
{
    public class RequestCreateDTO
    {
        public int ProjectId { get; set; }
        public int TypeId { get; set; }
        public int PriorityId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

    }
}
