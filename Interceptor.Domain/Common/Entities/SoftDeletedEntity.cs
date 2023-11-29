
namespace Interceptor.Domain.Common.Entities;

public class SoftDeletedEntity : AuditableEntity, ISoftDeletedEntity
{
    public bool IsDeleted { get; set; }

    public DateTime? DeletedDate { get; set; }
}