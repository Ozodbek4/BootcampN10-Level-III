using Interceptor.Domain.Common.Entities;

namespace Interceptor.Domain.Entities;

public class User : SoftDeletedEntity, ICreationAuditableEntity, IModificationAuditableEntity, IDeletionAuditableEntity
{
    public string FirstName { get; set; } = default!;

    public string LastName { get; set; } = default!;

    public byte Age { get; set; }

    public string EmailAddress { get; set; } = default!;

    public string Password { get; set; } = default!;
    
    public Guid CreatedByUserId { get; set; }
    
    public Guid? ModifiedByUserId { get; set; }
    
    public Guid? DeletedByUserId { get; set; }
}