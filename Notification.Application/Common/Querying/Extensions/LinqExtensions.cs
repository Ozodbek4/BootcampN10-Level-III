using Notification.Application.Common.Models.Querying;

namespace Notification.Application.Common.Querying.Extensions;

public static class LinqExtensions
{
    public static IQueryable<TSource> ApplyPagination<TSource>(this IQueryable<TSource> sources, FilterPagination filterPagination) =>
        sources.Skip((filterPagination.PageToken - 1) * filterPagination.PageSize).Take(filterPagination.PageSize);

    public static IEnumerable<TSource> ApplyPagination<TSource>(this IEnumerable<TSource> sources, FilterPagination filterPagination) =>
        sources.Skip((filterPagination.PageToken - 1) * filterPagination.PageSize).Take(filterPagination.PageSize);
}