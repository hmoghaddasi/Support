using System;

namespace Support.Domain.Model
{
    public class Response
    {
        public int ResponseId { get; set; }
        public DateTime ResponseDate { get; set; }
        public int CreateById { get; set; }
        public int RequestId { get; set; }
        public string Note { get; set; }
        public bool Private { get; set; }
        public virtual Person CreateBy { get; set; }
        public virtual Request Request { get; set; }


       

    }



}