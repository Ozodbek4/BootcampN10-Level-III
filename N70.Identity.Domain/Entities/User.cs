using N70.Identity.Domain.Common;

namespace N70.Identity.Domain.Entities;

public class User : IEntity
{
    public Guid Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public byte Age { get; set; }

    public string EmailAddress { get; set; }

    public string Password { get; set; }

    public bool IsEmailAddressVerified { get; set; }

    public Guid RoleId { get; set; }

    public virtual Role Role { get; set; }
}