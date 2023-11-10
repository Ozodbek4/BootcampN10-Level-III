namespace N70.Identity.Domain.Common;

public class AuditableEntity : IEntity
{
    public Guid Id { get; set; }

    public DateTimeOffset CreatedDate { get; set; } = DateTimeOffset.Now;

    public DateTimeOffset? ModifiedDate { get; set; }

    public bool IsDeleted { get; set; }

    public DateTimeOffset? DeletedDate { get; set; }
}