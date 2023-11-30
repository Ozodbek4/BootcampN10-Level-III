using Notification.Domain.Entities;

namespace Notification.Application.Common.Identities.Services;

public interface IUserSettingsService
{
    ValueTask<UserSettings?> GetUserSettingsAsync(Guid userSettingsId, bool asNoTracking = false);
}