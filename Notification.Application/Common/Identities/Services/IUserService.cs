using Notification.Domain.Entities;

namespace Notification.Application.Common.Identities.Services;

public interface IUserService
{
    ValueTask<IList<User>> GetByIdsAsync(IEnumerable<Guid> ids, bool asNoTracking = false);

    ValueTask<User?> GetSystemUserAsync(bool asNoTracking = false);

    ValueTask<User?> GetByIdsAsync(Guid id, bool asNoTracking = false);
}