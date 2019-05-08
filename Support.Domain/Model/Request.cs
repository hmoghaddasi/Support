using System;
using System.Collections.Generic;

namespace Support.Domain.Model
{
    public class Request
    {
        public int RequestId { get; set; }
        public DateTime RequestDate { get; set; }
        public int RequestById { get; set; }
        public int StatusId { get; set; }
        public int TypeId { get; set; }
        public int PriorityId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public int AssignedId { get; set; }
        public Person RequestBy { get; set; }
        public Config Status { get; set; }
        public Config Type { get; set; }
        public Config Priority { get; set; }

        public virtual Person Assigned { get; set; }
        public virtual List<Response> Responses { get; set; }


       

    }


}