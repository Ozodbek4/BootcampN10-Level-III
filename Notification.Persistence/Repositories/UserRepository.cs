using Notification.Domain.Entities;
using Notification.Persistence.DataContexts;
using Notification.Persistence.Repositories.Interfaces;
using System.Linq.Expressions;

namespace Notification.Persistence.Repositories;

public class UserRepository : EntityRepositoryBase<User, NotificationDbContext>, IUserRepository
{
    public UserRepository(NotificationDbContext dbContext) : base(dbContext)
    {
    }

    public IQueryable<User> Get(Expression<Func<User, bool>>? predicate = default, bool asNoTracking = false) =>
        base.Get(predicate, asNoTracking);

    public ValueTask<User?> GetByIdAsync(Guid id, bool asNoTracking = false) =>
        base.GetByIdAsync(id, asNoTracking);

    public ValueTask<IList<User>> GetByIdsAsync(IEnumerable<Guid> ids, bool asNoTracking = false) =>
        base.GetByIdsAsync(ids, asNoTracking);

    public new ValueTask<User> CreateAsnc(User user, bool saveChanges = true, CancellationToken cancellationToken = default) =>
        base.CreateAsnc(user, saveChanges, cancellationToken);

    public new ValueTask<User> DeleteAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default) =>
        base.DeleteAsync(user, saveChanges, cancellationToken);

    public new ValueTask<User> DeleteByIdAsnc(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default) =>
        base.DeleteByIdAsnc(id, saveChanges, cancellationToken);

    public new ValueTask<User> UpdateAsnc(User user, bool saveChanges = true, CancellationToken cancellationToken = default) =>
        base.UpdateAsnc(user, saveChanges, cancellationToken);
}