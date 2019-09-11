using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sun.net.www.content.text;

namespace Framework.Core.Treeview
{
    public class TCustomEntity<T> : Generic where T : class
    {
        public List<Children<T>> Childrens { get; set; }
    }

    public class Children<T>
    {
        
    }
}
