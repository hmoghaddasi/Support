using System;
using System.Collections.Generic;
using System.Text;

namespace Support.Application.Contract.DTO
{
    public class RequestEditDTO
    {
        public int RequestId { get; set; }
        public int RequestById { get; set; }
        public int StatusId { get; set; }
        public int TypeId { get; set; }
        public int PriorityId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
