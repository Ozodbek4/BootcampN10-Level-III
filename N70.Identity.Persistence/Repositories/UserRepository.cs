using Microsoft.EntityFrameworkCore;
using N70.Identity.Domain.Entities;
using N70.Identity.Persistence.Repositories.Interfaces;
using System.Linq.Expressions;

namespace N70.Identity.Persistence.Repositories;

public class UserRepository : EntityRepositoryBase<User, DbContext>, IUserRepository
{
    public UserRepository(DbContext dbContext) : base(dbContext)
    {
    }

    public new IQueryable<User?> Get(Expression<Func<User, bool>> predicate, bool asNoTracking = false, CancellationToken cancellationToken = default) =>
        base.Get(predicate, asNoTracking, cancellationToken);

    public new ValueTask<User?> GetByIdAsync(Guid id, bool asNoTracking = false, CancellationToken cancellationToken = default) =>
        base.GetByIdAsync(id, asNoTracking, cancellationToken);

    public new async ValueTask<IQueryable<User?>> GetAllAsync(bool asNoTracking = false, CancellationToken cancellationToken = default) =>
        base.Get(asNoTracking: asNoTracking, cancellationToken: cancellationToken);

    public new ValueTask<User> CreateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default) =>
        base.CreateAsync(user, saveChanges, cancellationToken);

    public ValueTask<User> UpdateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default) =>
        base.UpdateAsnyc(user, saveChanges, cancellationToken);
    
    public new ValueTask<User> DeleteByIdAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default) =>
        base.DeleteByIdAsync(id, saveChanges, cancellationToken);

    public new ValueTask<User> DeleteAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default) =>
        base.DeleteAsync(user, saveChanges, cancellationToken);
}