using Blog.Application.Services;
using Blog.Domain.Entities;
using Blog.Persistence.Repositories.Interfaces;

namespace Blog.Infrastructure.Services;

public class BlogService(IBlogRepository blogRepository) : IBlogService
{
    public ValueTask<IList<Blogs>> GetAllAsync(bool asNoTracking = false) =>
        blogRepository.GetAllAsync(asNoTracking);

    public ValueTask<Blogs?> GetByIdAsync(Guid id, bool asNoTracking = false, CancellationToken cancellationToken = default) =>
        blogRepository.GetByIdAsync(id, asNoTracking, cancellationToken);

    public ValueTask<Blogs> CreateAsync(Blogs blogs, bool saveChanges = true, CancellationToken cancellationToken = default) =>
        blogRepository.CreateAsync(blogs, saveChanges, cancellationToken);

    public ValueTask<Blogs> UpdateAsync(Blogs user, bool saveChanges = true, CancellationToken cancellationToken = default) =>
        blogRepository.UpdateAsync(user, saveChanges, cancellationToken);

    public ValueTask<Blogs> DeleteByIdAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default) =>
        blogRepository.DeleteByIdAsync(id, saveChanges, cancellationToken);
}