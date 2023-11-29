using Interceptor.Domain.Common.Entities;
using Interceptor.Domain.Settings;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Options;

namespace Interceptor.Persistence.Interceptors;

public class DeletedInterceptor(IOptions<AuditableSettings> setting) : SaveChangesInterceptor
{
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData,
        InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        var deletedAuditable = eventData.Context!.ChangeTracker.Entries<IDeletionAuditableEntity>().ToList();

        deletedAuditable.ForEach(entry =>
        {
            if (entry.State == Microsoft.EntityFrameworkCore.EntityState.Deleted)
                entry.Property(nameof(IDeletionAuditableEntity.DeletedByUserId)).CurrentValue = setting.Value.DeletedById;
        });

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}