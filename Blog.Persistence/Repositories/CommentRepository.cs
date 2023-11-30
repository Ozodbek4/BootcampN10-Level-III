using Blog.Domain.Entities;
using Blog.Persistence.DataContext;
using Blog.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Blog.Persistence.Repositories;

public class CommentRepository : EntityRepositoryBase<Comment, BlogDbContext>, ICommentRepsitory
{
    public CommentRepository(BlogDbContext context) : base(context)
    {
    }

    public IQueryable<Comment> Get(Expression<Func<Comment, bool>>? predicate = null, bool asNoTracking = false) =>
        base.Get(predicate, asNoTracking);

    public async ValueTask<IList<Comment>> GetAllAsync(bool asNoTracking = false) =>
        await base.Get(asNoTracking: asNoTracking).ToListAsync();

    public new ValueTask<Comment?> GetByIdAsync(Guid id, bool asNoTracking = false, CancellationToken cancellationToken = default) =>
        base.GetByIdAsync(id, asNoTracking, cancellationToken);

    public new ValueTask<Comment> CreateAsync(Comment blogs, bool saveChanges = true, CancellationToken cancellationToken = default) =>
        base.CreateAsync(blogs, saveChanges, cancellationToken);

    public ValueTask<Comment> UpdateAsync(Comment comment, bool saveChanges = true, CancellationToken cancellationToken = default) =>
        base.UpdateAsnyc(comment, saveChanges, cancellationToken);

    public new ValueTask<Comment> DeleteAsync(Comment blogs, bool saveChanges = true, CancellationToken cancellationToken = default) =>
        base.DeleteAsync(blogs, saveChanges, cancellationToken);

    public new ValueTask<Comment> DeleteByIdAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default) =>
        base.DeleteByIdAsync(id, saveChanges, cancellationToken);
}