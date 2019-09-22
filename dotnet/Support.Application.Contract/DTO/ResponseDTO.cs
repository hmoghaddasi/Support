using System;

namespace Support.Application.Contract.DTO
{
    public class ResponseDTO
    {
        public int ResponseId { get; set; }
        public DateTime ResponseDate { get; set; }
        public int CreateById { get; set; }
        public int RequestId { get; set; }
        public string Note { get; set; }
        public bool Private { get; set; }
        public string CreateBy { get; set; }
        public string Request { get; set; }
        public string ResponseShDate { get; set; }
    }
}