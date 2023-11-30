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
        var foundBlogs = blogRepository.Get(blog => blog.Comments.Count() >= filterPagination.BlogCount).ToList();

        return (await userRepository.GetAllAsync()).Where(user => foundBlogs.Any(blog => blog.UserId.Equals(user.Id))).ToList();
    }
}