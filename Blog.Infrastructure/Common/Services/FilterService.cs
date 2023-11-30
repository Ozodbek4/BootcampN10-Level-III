using Blog.Application.Common.Models;
using Blog.Application.Common.Services;
using Blog.Domain.Entities;
using Blog.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure.Common.Services;

public class FilterService(IBlogRepository blogRepository, IUserRepository userRepository) : IFilterService
{
    public async ValueTask<IList<User>> GetFilter(FilterPagination filterPagination)
    {
        var foundBlogs = blogRepository.Get(blog => blog.Comments.Count() > filterPagination.BloggerCount).ToList();

        return await userRepository.Get(user => foundBlogs.Any(blog => blog.Id == user.Id)).ToListAsync();
    }
}