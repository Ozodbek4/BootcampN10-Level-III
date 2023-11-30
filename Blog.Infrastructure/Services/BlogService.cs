using Blog.Application.Services;
using Blog.Domain.Entities;

namespace Blog.Infrastructure.Services;

public class BlogService : IBlogService
{
    public ValueTask<Blogs> CreateAsync(Blogs blogs, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public ValueTask<Blogs> DeleteByIdAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public ValueTask<IList<Blogs>> GetAllAsync(bool asNoTracking = false)
    {
        throw new NotImplementedException();
    }

    public ValueTask<Blogs?> GetByIdAsync(Guid id, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public ValueTask<Blogs> UpdateAsync(Blogs user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}