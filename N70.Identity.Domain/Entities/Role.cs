using N70.Identity.Domain.Common;
using N70.Identity.Domain.Enums;

namespace N70.Identity.Domain.Entities;

public class Role : IEntity
{
    public Guid Id { get; set; }

    public RoleType Type { get; set; } = RoleType.Host;

    public bool IsDisabled { get; set; }

    public DateTime CreatedTime { get; set; } = DateTime.Now;

    public DateTime? UpdatedTime { get; set; }
}