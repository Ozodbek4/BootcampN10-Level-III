using Notification.Domain.Entities;

namespace Notification.Application.Common.Identities.Services;

public interface IUserService
{
    ValueTask<IEnumerable<User>> GetAllAsync(bool asNoTracking = false);

    ValueTask<IList<User>> GetByIdsAsync(IEnumerable<Guid> ids, bool asNoTracking = false);

    ValueTask<User?> GetSystemUserAsync(bool asNoTracking = false);

    ValueTask<User?> GetByIdAsync(Guid id, bool asNoTracking = false, CancellationToken cancellationToken = default);

    ValueTask<User> CreateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<User> UpdateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<User> DeleteByIdAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<User> DeleteAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default);
}