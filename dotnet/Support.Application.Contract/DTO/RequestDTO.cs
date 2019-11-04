using System;

namespace Support.Application.Contract.DTO
{
    public class RequestDTO
    {
        public int RequestId { get; set; }
        public DateTime RequestDate { get; set; }
        public string RequestShDate { get; set; }
        public int RequestById { get; set; }
        public int StatusId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string RequestBy { get; set; }
        public string Status { get; set; }
        public int TypeId { get; set; }
        public string Type { get; set; }
        public int PriorityId { get; set; }
        public string Priority { get; set; }
        public int AssignedId { get; set; }
        public string Assigned { get; set; }
        public int ProjectId { get; set; }
        public string Project { get; set; }
    }
}