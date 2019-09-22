using System;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using EntityFramework.Extensions;
using Newtonsoft.Json;

namespace Framework.Core.Filtering
{
    public static class FilterExtensions
    {
        public static FilterResponse<T> ApplyFilters<T>(this IQueryable<T> query,
            GridRequest request, bool defaultSort=true) where T : class
        {

            if (!string.IsNullOrWhiteSpace(request.Filter))
            {
                request.FilterGrid = JsonConvert.DeserializeObject<GridFilter>(request.Filter);
            }

            if (request.FilterGrid != null)
            {
                FilterHelper.ProcessFilters(request.FilterGrid, ref query);

            }

            if (defaultSort) { 
            if (request.Sort != null && Enumerable.Any(request.Sort))
            {
                foreach (var sort in request.Sort)
                {
                    query = query.OrderBy($"{sort.Field} {sort.Dir}");
                }
            }
            else
            {
                var keyId = $@"{typeof(T).Name}Id";
                query = query.OrderBy(keyId+" ");
            }
            }
            var count = query.Count();
            var data = query.Skip(request.Skip).Take(request.Take).ToList();

            return new FilterResponse<T>(data, count);
        }
    }
}
