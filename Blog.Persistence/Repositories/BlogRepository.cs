using Blog.Domain.Entities;
using Blog.Persistence.DataContext;
using Blog.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Blog.Persistence.Repositories;

public class BlogRepository : EntityRepositoryBase<Blogs, BlogDbContext>, IBlogRepository
{
    public BlogRepository(BlogDbContext context) : base(context)
    {
    }

    public IQueryable<Blogs> Get(Expression<Func<Blogs, bool>>? predicate = null, bool asNoTracking = false) =>
        base.Get(predicate, asNoTracking);

    public async ValueTask<IList<Blogs>> GetAllAsync(bool asNoTracking = false) =>
        await base.Get(asNoTracking: asNoTracking).ToListAsync();

    public new ValueTask<Blogs?> GetByIdAsync(Guid id, bool asNoTracking = false, CancellationToken cancellationToken = default) =>
        base.GetByIdAsync(id, asNoTracking, cancellationToken);

    public new ValueTask<Blogs> CreateAsync(Blogs blogs, bool saveChanges = true, CancellationToken cancellationToken = default) =>
        base.CreateAsync(blogs, saveChanges, cancellationToken);

    public ValueTask<Blogs> UpdateAsync(Blogs user, bool saveChanges = true, CancellationToken cancellationToken = default) =>
        base.UpdateAsnyc(user, saveChanges, cancellationToken);

    public new ValueTask<Blogs> DeleteAsync(Blogs blogs, bool saveChanges = true, CancellationToken cancellationToken = default)=>
        base.DeleteAsync(blogs, saveChanges, cancellationToken);

    public new ValueTask<Blogs> DeleteByIdAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default) =>
        base.DeleteByIdAsync(id, saveChanges, cancellationToken);
}