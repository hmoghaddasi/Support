using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Core.Treeview
{
    public static class TreeView<TCustomEntity>
    {
        
        public static List<TCustomEntity> BuildTree(List<TCustomEntity> list, Expression<Func<TCustomEntity, bool>> predicate)
        {
            List<TCustomEntity> returnList = new List<TCustomEntity>();
            //find top levels items
            var topLevels = list.AsQueryable().Where(predicate);
            returnList.AddRange(topLevels);
            foreach (var i in topLevels)
            {
                GetTreeview(list, i, ref returnList, predicate);
            }
            return returnList;
        }

        public static void GetTreeview(List<TCustomEntity> list, TCustomEntity current, ref List<TCustomEntity> returnList, Expression<Func<TCustomEntity, bool>> predicate)
        {
            //get child of current item
            var childs = list.AsQueryable().Where(predicate).ToList();
            //current.Childrens = new List<TCustomEntity>();
            //current.Childrens.AddRange(childs);
            foreach (var i in childs)
            {
                GetTreeview(list, i, ref returnList, predicate);
            }
        }
    }
}
