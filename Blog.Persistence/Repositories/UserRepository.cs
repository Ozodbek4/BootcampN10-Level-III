using Blog.Domain.Entities;
using Blog.Persistence.DataContext;
using Blog.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Blog.Persistence.Repositories;

public class UserRepository : EntityRepositoryBase<User, BlogDbContext>, IUserRepository
{
    public UserRepository(BlogDbContext context) : base(context)
    {
    }

    public IQueryable<User> Get(Expression<Func<User, bool>>? predicate = null, bool asNoTracking = false) =>
        base.Get(predicate, asNoTracking);

    public new ValueTask<User?> GetByIdAsync(Guid id, bool asNoTracking = false, CancellationToken cancellationToken = default) =>
        base.GetByIdAsync(id, asNoTracking, cancellationToken);

    public async ValueTask<IList<User>> GetAllAsync(bool asNoTracking = false) =>
        await base.Get(asNoTracking: asNoTracking).ToListAsync();

    public new ValueTask<User> CreateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default) =>
        base.CreateAsync(user, saveChanges, cancellationToken);

    public ValueTask<User> UpdateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default) =>
        base.UpdateAsnyc(user, saveChanges, cancellationToken);

    public new ValueTask<User> DeleteAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default) =>
        base.DeleteAsync(user, saveChanges, cancellationToken);

    public ValueTask<User> DeleteByIdAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default) =>
        base.DeleteByIdAsync(id, saveChanges, cancellationToken);
}