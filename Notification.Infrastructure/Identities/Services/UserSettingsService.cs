using Notification.Application.Common.Identities.Services;
using Notification.Domain.Entities;
using Notification.Persistence.Repositories.Interfaces;

namespace Notification.Infrastructure.Identities.Services;

public class UserSettingsService : IUserSettingsService
{
    private readonly IUserSettingsRepository _userSettingsRepository;

    public UserSettingsService(IUserSettingsRepository userSettingsRepository)
    {
        _userSettingsRepository = userSettingsRepository;
    }

    public async ValueTask<UserSettings?> GetUserSettingsAsync(Guid userSettingsId, bool asNoTracking = false) =>
        await _userSettingsRepository.GetByIdAsync(userSettingsId, asNoTracking);
}