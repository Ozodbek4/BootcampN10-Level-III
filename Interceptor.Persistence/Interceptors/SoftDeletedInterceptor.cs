using Interceptor.Domain.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Interceptor.Persistence.Interceptors;

public class SoftDeletedInterceptor : SaveChangesInterceptor
{
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData,
        InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        var auditableEntities = eventData.Context!.ChangeTracker.Entries<ISoftDeletedEntity>().ToList();

        auditableEntities.ForEach(entry =>
            {
                if (entry.State != EntityState.Deleted)
                    return;

                entry.Property(nameof(ISoftDeletedEntity.DeletedDate)).CurrentValue = DateTime.Now;
                entry.Property(nameof(ISoftDeletedEntity.IsDeleted)).CurrentValue = true;
                entry.State = EntityState.Modified;
            }
        );

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}