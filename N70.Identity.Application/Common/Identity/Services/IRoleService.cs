using N70.Identity.Domain.Entities;
using N70.Identity.Domain.Enums;

namespace N70.Identity.Application.Common.Identity.Services;

public interface IRoleService
{
    ValueTask<Role?> GetByTypeAsync(RoleType type, bool asNoTracking = false, CancellationToken cancellationToken = default)
}