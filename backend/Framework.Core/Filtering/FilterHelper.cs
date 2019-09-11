using Framework.Core.Predicate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Framework.Core.Filtering
{
    public static class FilterHelper
    {
        public static void ProcessFilters<T>(GridFilter filter, ref IQueryable<T> queryable)
        {
            var whereClause = string.Empty;
            var filters = filter.Filters;
            var parameters = new List<object>();
            for (int i = 0; i < filters.Count; i++)
            {
                var f = filters[i];

                if (f.perdict != null)
                {
                    var perdict = (Expression<Func<T, bool>>)f.perdict;
                    queryable = queryable.Where(perdict);
                }
                else if (f.Filters == null)
                {
                    Expression<Func<T, bool>> func = ExpressionBuilder.strToFunc<T>(f.Field, f.Operator, f.Value);
                    queryable = queryable.Where(func);
                }
                else
                    ProcessFilters(f, ref queryable);
            }
        }
    }
}
