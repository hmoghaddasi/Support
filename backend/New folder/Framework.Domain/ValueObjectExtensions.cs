using System.Collections.Generic;
using System.Linq;

namespace Framework.Domain
{
    public static class ValueObjectExtensions
    {
        //جهت ذخیره مدل های مستر و دیتیل استفاده می گردد
        public static void Update<T>(this List<T> source,
            List<T> target) where T : IValueObject
        {
            var added = target.Except(source).ToList();
            var deleted = source.Except(target).ToList();

            deleted.ForEach(a => source.Remove(a));
            added.ForEach(a => source.Add(a));
        }
    }
}