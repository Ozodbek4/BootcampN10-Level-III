using Microsoft.EntityFrameworkCore;
using Notification.Application.Common.Identities.Services;
using Notification.Domain.Entities;
using Notification.Domain.Enums;
using Notification.Persistence.Repositories.Interfaces;

namespace Notification.Infrastructure.Identities.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public ValueTask<IList<User>> GetByIdsAsync(
        IEnumerable<Guid> ids,
        bool asNoTracking = false
    ) =>
        _userRepository.GetByIdsAsync(ids, asNoTracking);

    public async ValueTask<User?> GetSystemUserAsync(bool asNoTracking = false)
    {
        return await _userRepository.Get(user => user.Role == RoleType.System, asNoTracking)
            .Include(user => user.UserSettings)
            .SingleOrDefaultAsync();
    }

    public ValueTask<User?> GetByIdAsync(
        Guid ids,
        bool asNoTracking = false
    ) =>
        _userRepository.GetByIdAsync(ids, asNoTracking);
}