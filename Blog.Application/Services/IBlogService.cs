using Blog.Domain.Entities;

namespace Blog.Application.Services;

public interface IBlogService
{
    ValueTask<Blogs?> GetByIdAsync(Guid id, bool asNoTracking = false, CancellationToken cancellationToken = default);

    ValueTask<IList<Blogs>> GetAllAsync(bool asNoTracking = false);

    ValueTask<Blogs> CreateAsync(Blogs blogs, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Blogs> UpdateAsync(Blogs user, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Blogs> DeleteByIdAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default);
}