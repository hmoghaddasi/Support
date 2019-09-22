using System.Collections.Generic;

namespace Support.Domain.Model
{
    public class Config
    {
        public int ConfigId { get; set; }
        public int ConfigHdrId { get; set; }
        public string ConfigName { get; set; }
        public int ConfigValue { get; set; }
        public string ConfigNote { get; set; }
        public int ConfigSort { get; set; }
        public string ClassName { get; set; }
        public virtual Config ConfigHdr { get; set; }
    }
}
