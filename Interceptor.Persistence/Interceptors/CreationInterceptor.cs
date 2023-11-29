using Interceptor.Domain.Common.Entities;
using Interceptor.Domain.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Options;

namespace Interceptor.Persistence.Interceptors;

public class CreationInterceptor(IOptions<AuditableSettings> setting) : SaveChangesInterceptor
{
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData,
        InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        var creationEntry = eventData.Context!.ChangeTracker.Entries<ICreationAuditableEntity>().ToList();

        creationEntry.ForEach(entry =>
        {
            if (entry.State == EntityState.Added)
                entry.Property(nameof(ICreationAuditableEntity.CreatedByUserId)).CurrentValue = setting.Value.CreatedById;
        });

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}