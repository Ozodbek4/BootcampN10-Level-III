using Blog.Application.Common.Models;
using Blog.Domain.Entities;

namespace Blog.Application.Common.Services;

public interface IFilterService
{
    ValueTask<IList<User>> GetFilter(FilterPagination filterPagination);
}