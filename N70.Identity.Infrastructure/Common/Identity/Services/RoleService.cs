using Microsoft.EntityFrameworkCore;
using N70.Identity.Application.Common.Identity.Services;
using N70.Identity.Domain.Entities;
using N70.Identity.Domain.Enums;
using N70.Identity.Persistence.Repositories.Interfaces;

namespace N70.Identity.Infrastructure.Common.Identity.Services;

public class RoleService : IRoleService
{
    private readonly IRoleRepository _roleRepository;

    public RoleService(IRoleRepository roleRepository) =>
        _roleRepository = roleRepository;

    public async ValueTask<Role?> GetByTypeAsync(RoleType type, bool asNoTracking = false, CancellationToken cancellationToken = default) =>
        await _roleRepository.Get(asNoTracking: asNoTracking)
            .SingleOrDefaultAsync(role => role.Type == type, cancellationToken);
}