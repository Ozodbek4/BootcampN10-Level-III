using N70.Identity.Domain.Common;

namespace N70.Identity.Domain.Entities;

public class AccessToken : IEntity
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public string Value { get; set; }

    public bool IsRevoked { get; set; }

    public DateTime CreatedTime { get; set; }
}