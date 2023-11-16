using Notification.Domain.Entities;
using Notification.Persistence.DataContexts;
using Notification.Persistence.Repositories.Interfaces;
using System.Linq.Expressions;

namespace Notification.Persistence.Repositories;

public class SmsHistoryRepository : EntityRepositoryBase<SmsHistory, NotificationDbContext>, ISmsHistoryRepository
{
    public SmsHistoryRepository(NotificationDbContext dbContext) : base(dbContext)
    {
    }

    public IQueryable<SmsHistory> Get(Expression<Func<SmsHistory, bool>>? predicate, bool asNoTracking) =>
        base.Get(predicate, asNoTracking);

    public new ValueTask<SmsHistory> CreateAsync(SmsHistory smsHistory, bool saveChanges = false, CancellationToken cancellationToken = default) =>
        base.CreateAsync(smsHistory, saveChanges, cancellationToken);
}