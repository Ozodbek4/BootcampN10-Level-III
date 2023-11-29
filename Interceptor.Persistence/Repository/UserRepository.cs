using Interceptor.Domain.Entities;
using Interceptor.Persistence.DataContext;
using Interceptor.Persistence.Repository.Interfaces;
using System.Linq.Expressions;

namespace Interceptor.Persistence.Repository;

public class UserRepository : EntityRepositoryBase<User, IdentityDbContext>, IUserRepository
{
    public UserRepository(IdentityDbContext dbContext) : base(dbContext)
    {
    }

    public new IQueryable<User> Get(Expression<Func<User, bool>> predicate, bool asNoTracking = false, CancellationToken cancellationToken = default) =>
        base.Get(predicate, asNoTracking, cancellationToken);

    public new ValueTask<User?> GetByIdAsync(Guid id, bool asNoTracking = false, CancellationToken cancellationToken = default) =>
        base.GetByIdAsync(id, asNoTracking, cancellationToken);

    public new ValueTask<IList<User>> GetByIdsAsync(IEnumerable<Guid> ids, bool asNoTracking = false, CancellationToken cancellationToken = default) =>
        base.GetByIdsAsync(ids, asNoTracking, cancellationToken);

    public new ValueTask<User> CreateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default) =>
        base.CreateAsync(user, saveChanges, cancellationToken);

    public new ValueTask<User> UpdateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default) =>
        base.UpdateAsync(user, saveChanges, cancellationToken);

    public new ValueTask<User> DeleteAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default) =>
        base.DeleteAsync(user, saveChanges, cancellationToken);

    public new ValueTask<User> DeleteByIdAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default) =>
        base.DeleteByIdAsync(id, saveChanges, cancellationToken);

    public new ValueTask<IList<User>> DeleteByIdsAsync(IEnumerable<Guid> ids, bool saveChanges = true, CancellationToken cancellationToken = default) =>
        base.DeleteByIdsAsync(ids, saveChanges, cancellationToken);
}