using Notification.Domain.Entities;
using Notification.Persistence.DataContexts;
using Notification.Persistence.Repositories.Interfaces;

namespace Notification.Persistence.Repositories;

public class UserSettingsRepository : EntityRepositoryBase<UserSettings, NotificationDbContext>, IUserSettingsRepository
{
    public UserSettingsRepository(NotificationDbContext dbContext) : base(dbContext)
    {
    }

    public ValueTask<UserSettings> GetByIdAsync(Guid Id, bool asNoTracking = false) =>
        base.GetByIdAsync(Id, asNoTracking)!;
}