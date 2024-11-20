using Collector.Client.Dtos;

namespace Collector.Client.Helpers
{
    public static class QueryableExtension
    {
        public static IQueryable<T> Pagination<T>(this IQueryable<T> queryable, PaginationDto pagination)
        {
            return queryable
                .Skip((pagination.Page - 1) * pagination.AmountofInfo)
                .Take(pagination.AmountofInfo);
        }
    }
}
