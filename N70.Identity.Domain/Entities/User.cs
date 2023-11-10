using N70.Identity.Domain.Common;

namespace N70.Identity.Domain.Entities;

public class User : AuditableEntity
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public byte Age { get; set; }

    public string EmailAddress { get; set; }
}