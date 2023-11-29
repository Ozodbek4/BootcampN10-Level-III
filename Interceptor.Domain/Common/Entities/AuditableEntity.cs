
namespace Interceptor.Domain.Common.Entities;

public class AuditableEntity : Entity, IAuditableEntity
{
    public DateTime CreatedDate { get; set; }
    
    public DateTime? ModifiedDate { get; set; }
}