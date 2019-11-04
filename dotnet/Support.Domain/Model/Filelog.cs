using System;

namespace Support.Domain.Model
{
    public class FileLog
    {
        public int FileLogId { set; get; }
        public DateTime CreateDate { set; get; }
        public string FileUrl { set; get; }
        public int DayCountId { get; set; }
        public virtual Config DayCount { get; set; }
    }
}