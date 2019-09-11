using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Core.Exception
{
    public class BusinessException : System.Exception
    {
        private int Code { get; set; }

        protected BusinessException(int code, string message) : base(message)
        {
            Code = code;
        }
        
    }
}
