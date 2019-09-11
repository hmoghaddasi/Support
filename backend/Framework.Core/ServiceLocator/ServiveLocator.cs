using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Core.ServiceLocator
{

    public static class ServiveLocator
    {
        public static IServiveLocator Current { get; set; }

        public static void SetCurrent(IServiveLocator Locator)
        {
            Current = Locator;
        }
    }
}
