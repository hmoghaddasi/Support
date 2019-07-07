using System;
using System.Collections.Generic;
using System.Text;

namespace Support.Application.Contract.DTO
{
    public class RequestListDTO
    {
        public int RequestId { get; set; }
        public DateTime RequestDate { get; set; }
        public string RequestBy { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public string Priority { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public string Assigned { get; set; }
    }
}
