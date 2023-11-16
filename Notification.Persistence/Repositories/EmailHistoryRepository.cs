using Notification.Domain.Entities;
using Notification.Persistence.DataContexts;
using Notification.Persistence.Repositories.Interfaces;
using System.Linq.Expressions;

namespace Notification.Persistence.Repositories;

public class EmailHistoryRepository : EntityRepositoryBase<EmailHistory, NotificationDbContext>, IEmailHistoryRepository
{
    public EmailHistoryRepository(NotificationDbContext dbContext) : base(dbContext)
    {
    }

    public IQueryable<EmailHistory> Get(Expression<Func<EmailHistory, bool>>? predicate, bool asNoTracking) =>
        base.Get(predicate, asNoTracking);

    public new ValueTask<EmailHistory> CreateAsync(EmailHistory emailHistory, bool saveChanges = true, CancellationToken cancellationToken = default)  =>
        base.CreateAsync(emailHistory, saveChanges, cancellationToken);
}