using Blog.Application.Services;
using Blog.Domain.Entities;
using Blog.Persistence.Repositories.Interfaces;

namespace Blog.Infrastructure.Services;

public class CommentService(ICommentRepsitory commentRepsitory) : ICommentService
{
    public ValueTask<IList<Comment>> GetAllAsync(bool asNoTracking = false) =>
        commentRepsitory.GetAllAsync(asNoTracking);

    public ValueTask<Comment?> GetByIdAsync(Guid id, bool asNoTracking = false, CancellationToken cancellationToken = default) =>
        commentRepsitory.GetByIdAsync(id, asNoTracking, cancellationToken);
    
    public ValueTask<Comment> CreateAsync(Comment comment, bool saveChanges = true, CancellationToken cancellationToken = default) =>
        commentRepsitory.CreateAsync(comment, saveChanges, cancellationToken);
    
    public ValueTask<Comment> UpdateAsync(Comment comment, bool saveChanges = true, CancellationToken cancellationToken = default) =>
        commentRepsitory.UpdateAsync(comment, saveChanges, cancellationToken);

    public ValueTask<Comment> DeleteByIdAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default) =>
        commentRepsitory.DeleteByIdAsync(id, saveChanges, cancellationToken);
}