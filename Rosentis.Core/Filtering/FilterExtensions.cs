using System.Linq;
using System.Linq.Dynamic;
using EntityFramework.Extensions;


namespace Rosentis.Core.Filtering
{
    public static class FilterExtensions
    {
        public static FilterResponse<T> ApplyFilter<T>(this IQueryable<T> query,
            GridRequest request, bool defaultSort=true) where T : class
        {
            if (request.Filter != null)
                FilterHelper.ProcessFilters(request.Filter, ref query);

            //if (request.Filter != null && request.Filter.perdict != null)
            //{
            //    var perdict = (Expression<Func<T, bool>>) request.Filter.perdict;

            //    query = query.Where(perdict);
            //}


            if (defaultSort)
            {
                if (request.Sort != null && Enumerable.Any(request.Sort))
                {
                    foreach (var sort in request.Sort)
                    {
                        if (sort.Field == "RangeTypeDesc")
                            sort.Field = "RangeTypeId";

                        query = query.OrderBy($"{sort.Field} {sort.Dir}");
                    }
                }
                else
                {
                    var keyId = $@"Id";
                    query = query.OrderBy(keyId + " desc");
                }
            }
            var skip = (request.Page - 1) * request.PageSize;

   

            var count = query.Count();


            var data = query.Skip(skip).Take(request.PageSize).ToList();

            return new FilterResponse<T>(data, count);
        }

        public static FilterResponse<T> ApplyFilterForList<T>(this IQueryable<T> query,
          GridRequest request, bool defaultSort = true) where T : class
        {
            if (request.Filter != null)
                FilterHelper.ProcessFilters(request.Filter, ref query);

            
            if (defaultSort)
            {
                if (request.Sort != null && Enumerable.Any(request.Sort))
                {
                    foreach (var sort in request.Sort)
                    {
                        query = query.OrderBy($"{sort.Field} {sort.Dir}");
                    }
                }
                else
                {
                    var keyId = $@"Id";
                    query = query.OrderBy(keyId + " desc");
                }
            }
            var skip = (request.Page - 1) * request.PageSize;

            var count = query.Count();
            var data = query.Skip(skip).Take(request.PageSize).ToList();

            return new FilterResponse<T>(data, count);
        }

        public static FilterResponse<T> ApplyFilterById<T>(this IQueryable<T> query,
            GridRequest request, bool defaultSort = true) where T : class
        {
            if (request.Filter != null)
                FilterHelper.ProcessFilters(request.Filter, ref query);

            //if (request.Filter != null && request.Filter.perdict != null)
            //{
            //    var perdict = (Expression<Func<T, bool>>) request.Filter.perdict;

            //    query = query.Where(perdict);
            //}


            if (defaultSort)
            {
                if (request.Sort != null && Enumerable.Any(request.Sort))
                {
                    foreach (var sort in request.Sort)
                    {
                        if (sort.Field == "RangeTypeDesc")
                            sort.Field = "RangeTypeId";

                        query = query.OrderBy($"{sort.Field} {sort.Dir}");
                    }
                }
                else
                {
                    var keyId = $@"Id";
                    query = query.OrderBy(keyId + " desc");
                }
            }
            var skip = (request.Page - 1) * request.PageSize;



            var count = query.Count();


            var data = query.Skip(skip).Take(request.PageSize).ToList();

            return new FilterResponse<T>(data, count);
        }
    }
}
