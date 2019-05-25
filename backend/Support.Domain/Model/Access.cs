using System.Collections.Generic;
using System;

namespace Support.Domain.Model
{

    public class Access
    {
        
        public int AccessId { get; set; }
        public string AccessName { get; set; }
        public string AccessDesc { get; set; }
        public bool IsGeneral { get; set; }

        public virtual List<AccessPolicy> AccessPolicies { get; set; }

     
    }
}

