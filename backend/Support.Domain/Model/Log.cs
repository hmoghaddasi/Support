using System;

namespace Support.Domain.Model {
    public class Log
    {
        public int LogId { get; set; }
        public DateTime Date { get; set; }
        public string EntityName { get; set; }
        public int PersonId { get; set; }
        public string Description { get; set; }
        public int ChangeTypeId { get; set; }
        public int PrimaryKey { get; set; }
        
        public virtual Person Person { get; set; }


       
    }
}