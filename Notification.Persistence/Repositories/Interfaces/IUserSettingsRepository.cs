using Notification.Domain.Entities;

namespace Notification.Persistence.Repositories.Interfaces;

public interface IUserSettingsRepository
{
    ValueTask<UserSettings> GetByIdAsync(Guid Id, bool asNoTracking = false);
}