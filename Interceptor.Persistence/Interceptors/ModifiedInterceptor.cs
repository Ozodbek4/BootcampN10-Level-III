using Interceptor.Domain.Common.Entities;
using Interceptor.Domain.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Options;

namespace Interceptor.Persistence.Interceptors;

public class ModifiedInterceptor(IOptions<AuditableSettings> setting) : SaveChangesInterceptor
{
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData,
        InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        var modifiedAuditable = eventData.Context!.ChangeTracker.Entries<IModificationAuditableEntity>().ToList();

        modifiedAuditable.ForEach(entry =>
        {
            if (entry.State == EntityState.Modified)
                entry.Property(nameof(IModificationAuditableEntity)).CurrentValue = setting.Value.ModifiedById;
        });

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}