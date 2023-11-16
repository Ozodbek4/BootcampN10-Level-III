using Notification.Domain.Entities;
using Notification.Persistence.DataContexts;
using Notification.Persistence.Repositories.Interfaces;
using System.Linq.Expressions;

namespace Notification.Persistence.Repositories;

public class SmsTemplateRepository : EntityRepositoryBase<SmsTemplate, NotificationDbContext>, ISmsTemplateRepository
{
    public SmsTemplateRepository(NotificationDbContext dbContext) : base(dbContext)
    {
    }

    public IQueryable<SmsTemplate> Get(Expression<Func<SmsTemplate, bool>>? expression, bool asNoTracking) =>
        Get(expression, asNoTracking);

    public ValueTask<SmsTemplate> CreateAsync(SmsTemplate smsTemplate, bool saveChanges = true, CancellationToken cancellationToken = default) =>
        base.CreateAsnc(smsTemplate, saveChanges, cancellationToken);
}