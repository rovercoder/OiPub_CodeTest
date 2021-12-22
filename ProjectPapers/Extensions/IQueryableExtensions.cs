using ProjectPapers.DB.Models;
using System.Linq.Expressions;

namespace ProjectPapers.Extensions
{
    public static class IQueryableExtensions
    {
        public static IOrderedQueryable<TSource> OrderBy<TSource>(this IQueryable<TSource> source, string propertyName)
        {
            return source.OrderBy(ToLambda<TSource>(propertyName));
        }
        public static IOrderedQueryable<TSource> OrderByDescending<TSource>(this IQueryable<TSource> source, string propertyName)
        {
            return source.OrderByDescending(ToLambda<TSource>(propertyName));
        }
        private static Expression<Func<TSource, object>> ToLambda<TSource>(string propertyName)
        {
            var parameter = Expression.Parameter(typeof(TSource));
            var property = Expression.Property(parameter, propertyName);
            var propAsObject = Expression.Convert(property, typeof(object));
            return Expression.Lambda<Func<TSource, object>>(propAsObject, parameter);
        }
        public static async Task<PaginatedList<TSource>> ToPaginatedList<TSource>(this IQueryable<TSource> source, uint currentPage, uint pageSize)
        {
            return await PaginatedList<TSource>.CreateAsync(source, currentPage, pageSize);
        }
    }
}
