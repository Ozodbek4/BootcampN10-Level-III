using N70.Identity.Domain.Common;

namespace N70.Identity.Domain.Entities;

public class User : IEntity
{
    public Guid Id { get; set; }

    public string FirstName { get; set; } = default!;

    public string LastName { get; set; } = default!;

    public byte Age { get; set; }

    public string EmailAddress { get; set; } = default!;

    public string Password { get; set; } = default!;

    public bool IsEmailAddressVerified { get; set; }

    public Guid RoleId { get; set; }

    public ICollection<Role> Role { get; set; } = new List<Role>();
}