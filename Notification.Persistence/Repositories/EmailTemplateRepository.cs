using Notification.Domain.Entities;
using Notification.Persistence.DataContexts;
using Notification.Persistence.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Persistence.Repositories;

public class EmailTemplateRepository : EntityRepositoryBase<EmailTemplate, NotificationDbContext>, IEmailTemplateRepository
{
    public EmailTemplateRepository(NotificationDbContext dbContext) : base(dbContext)
    {
    }

    public IQueryable<EmailTemplate> Get(Expression<Func<EmailTemplate, bool>>? predicate, bool asNoTracking) =>
        base.Get(predicate, asNoTracking);

    public new ValueTask<EmailTemplate> CreateAsync(EmailTemplate emailTemplate, bool saveChanges = true, CancellationToken cancellationToken = default) =>
        base.CreateAsync(emailTemplate, saveChanges, cancellationToken);
}