using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace Framework.Core.Filtering
{
    public static class FilterExtensions
    {
        public static FilterResponse<T> ApplyFilters<T>(this IQueryable<T> query,
            GridRequest request, bool defaultSort = true) where T : class
        {
            if (request.Filter != null)
                FilterHelper.ProcessFilters(request.FilterX, ref query);
            if (defaultSort)
            {
                if (request.Sort != null && Enumerable.Any(request.Sort))
                {
                    foreach (var sort in request.Sort)
                    {
                        // TODO Add sorting                    
                        query = query.OrderBy($"{sort.Field} {sort.Dir}");
                    }
                }
                else
                {
                    var keyId = $@"{typeof(T).Name}Id";
                    // TODO Add sorting
                    query = query.OrderBy(keyId + " desc");
                }
            }
            var count = query.Count();
            var data = query.Skip(request.Skip).Take(request.Take).ToList();

            return new FilterResponse<T>(data, count);
        }
        public static FilterResponse<T> ApplyFilters<T>(this IQueryable<T> query,
           GridRequest request, Expression<Func<T, bool>> predicate, bool defaultSort = true) where T : class
        {
            if (request.FilterX != null)
                FilterHelper.ProcessFilters(request.FilterX, ref query);

            if (defaultSort)
            {
                if (request.Sort != null && Enumerable.Any(request.Sort))
                {
                    foreach (var sort in request.Sort)
                    {
                        // TODO Add sorting
                        query = query.OrderBy($"{sort.Field} {sort.Dir}");
                    }
                }
                else
                {
                    var keyId = $@"{typeof(T).Name}Id";
                    // TODO Add sorting
                    query = query.OrderBy(keyId + " desc");
                }
            }
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            var count = query.Count();
            var data = query.Skip(request.Skip).Take(request.Take).ToList();

            return new FilterResponse<T>(data, count);
        }
    }
}
