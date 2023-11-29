namespace Interceptor.Domain.Common.Entities;

public interface IAuditableEntity : IEntity
{
    DateTime CreatedDate { get; set; }

    DateTime? ModifiedDate { get; set; }
}