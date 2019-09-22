using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Core.Exception
{
  public  class ExceptionLogger
    { 

    public static void ErrorLogging(System.Exception ex, string logPath)
{

      if (!System.IO.File.Exists(logPath))
        {
            System.IO.File.Create(logPath).Dispose();
        }
        using (StreamWriter sw = System.IO.File.AppendText(logPath))
        {
        sw.WriteLine("=========== Start Error Logging ");
        sw.WriteLine("Error Time: " + System.DateTime.Now);
        sw.WriteLine("Error Message: " + ex.Message);
        sw.WriteLine("Stack Trace: " + ex.StackTrace);
        sw.WriteLine("=========== End ");

        }
}

    }
}
