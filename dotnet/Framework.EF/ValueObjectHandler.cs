using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Framework.EF
{
    public static class ValueObjectHandler
    {
        //موقع حذف رکورد از دیتیل استفاده می شود
        public static void HandleValueObject<TMaster, TDetail>(this DbContext context,
            Func<TMaster, List<TDetail>> childAccessor)
                where TMaster : class
                where TDetail : class
        {
            var childsInTracker = context.ChangeTracker
               .Entries()
               .Select(a => a.Entity)
               .OfType<TDetail>()
               .ToList();

            var master = context.ChangeTracker
                .Entries()
                .Select(a => a.Entity)
                .OfType<TMaster>()
                .FirstOrDefault();

            if (master != null)
            {
                var itemsToDelete = childsInTracker.Except(childAccessor(master)).ToList();
                context.Set<TDetail>().RemoveRange(itemsToDelete);
            }
        }
    }
}
