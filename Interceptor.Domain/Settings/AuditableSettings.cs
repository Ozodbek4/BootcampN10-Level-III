namespace Interceptor.Domain.Settings;

public class AuditableSettings
{
    public Guid CreatedById { get; set; }

    public Guid ModifiedById { get; set; }

    public Guid DeletedById { get; set; }
}