using Interceptor.Domain.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Interceptor.Persistence.Interceptors;

public class AuditableInterceptor : SaveChangesInterceptor
{
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData,
        InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        var auditableEntry = eventData.Context!.ChangeTracker.Entries<IAuditableEntity>().ToList();

        auditableEntry.ForEach(entry =>
        {
            if (entry.State == EntityState.Added)
                entry.Property(nameof(IAuditableEntity.CreatedDate)).CurrentValue = DateTime.UtcNow;
                                                                                             
            if (entry.State == EntityState.Modified)                                         
                entry.Property(nameof(IAuditableEntity.ModifiedDate)).CurrentValue = DateTime.UtcNow;
        });

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}