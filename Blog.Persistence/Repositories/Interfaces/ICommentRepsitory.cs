using Blog.Domain.Entities;
using System.Linq.Expressions;

namespace Blog.Persistence.Repositories.Interfaces;

public interface ICommentRepsitory
{
    IQueryable<Comment> Get(Expression<Func<Comment, bool>>? predicate = default, bool asNoTracking = false);

    ValueTask<Comment?> GetByIdAsync(Guid id, bool asNoTracking = false, CancellationToken cancellationToken = default);

    ValueTask<IList<Comment>> GetAllAsync(bool asNoTracking = false);

    ValueTask<Comment> CreateAsync(Comment comment, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Comment> UpdateAsync(Comment comment, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Comment> DeleteByIdAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Comment> DeleteAsync(Comment comment, bool saveChanges = true, CancellationToken cancellationToken = default);
}