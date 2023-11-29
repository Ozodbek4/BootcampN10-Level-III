namespace Interceptor.Domain.Common.Entities;

public interface ISoftDeletedEntity : IAuditableEntity
{
    bool IsDeleted { get; set; }
    
    DateTime? DeletedDate { get; set; }
}