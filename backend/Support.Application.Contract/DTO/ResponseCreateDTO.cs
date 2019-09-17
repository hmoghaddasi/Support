using System;

namespace Support.Application.Contract.DTO
{
    public class ResponseCreateDTO
    {
        public int ResponseId { get; set; }
        public DateTime ResponseDate { get; set; }
        public int CreateById { get; set; }
        public int RequestId { get; set; }
        public string Note { get; set; }
        public bool Private { get; set; }
    }
}