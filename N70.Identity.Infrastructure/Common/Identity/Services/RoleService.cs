using N70.Identity.Application.Common.Identity.Services;
using N70.Identity.Domain.Entities;
using N70.Identity.Domain.Enums;

namespace N70.Identity.Infrastructure.Common.Identity.Services;

public class RoleService : IRoleService
{
    public ValueTask<Role?> GetByTypeAsync(RoleType type, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}