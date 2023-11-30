using Blog.Domain.Entities;
using System.Linq.Expressions;

namespace Blog.Persistence.Repositories.Interfaces;

public interface IBlogRepository
{
    IQueryable<Blogs> Get(Expression<Func<Blogs, bool>>? predicate = default, bool asNoTracking = false);

    ValueTask<Blogs?> GetByIdAsync(Guid id, bool asNoTracking = false, CancellationToken cancellationToken = default);

    ValueTask<IList<Blogs>> GetAllAsync(bool asNoTracking = false);

    ValueTask<Blogs> CreateAsync(Blogs blogs, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Blogs> UpdateAsync(Blogs user, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Blogs> DeleteByIdAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Blogs> DeleteAsync(Blogs blogs, bool saveChanges = true, CancellationToken cancellationToken = default);
}