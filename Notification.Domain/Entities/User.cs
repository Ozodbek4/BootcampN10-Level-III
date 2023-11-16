using Notification.Domain.Common.Entities;

namespace Notification.Domain.Entities;

public class User : IEntity
{
    public Guid Id { get; set; }

    public string FirstName { get; set; } = default!;

    public string LastName { get; set; } = default!;

    public byte Age { get; set; }

    public string EmailAddress { get; set; } = default!;

    public string Password { get; set; } = default!;

    public string PhoneNumber { get; set; } = default!;

    public UserSettings UserSettings { get; set; }
}