using Blog.Application.Services;
using Blog.Domain.Entities;

namespace Blog.Infrastructure.Services;

public class CommentService : ICommentService
{
    public ValueTask<Comment> CreateAsync(Comment comment, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public ValueTask<Comment> DeleteByIdAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public ValueTask<IList<Comment>> GetAllAsync(bool asNoTracking = false)
    {
        throw new NotImplementedException();
    }

    public ValueTask<Comment?> GetByIdAsync(Guid id, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public ValueTask<Comment> UpdateAsync(Comment comment, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}