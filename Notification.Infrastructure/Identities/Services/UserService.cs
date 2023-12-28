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
        bool asNoTracking = false,
        CancellationToken cancellationToken = default
    ) =>
        _userRepository.GetByIdAsync(ids, asNoTracking);

    public ValueTask<IEnumerable<User>> GetAllAsync(bool asNoTracking = false) =>
        new(_userRepository.Get(asNoTracking: true));

    public ValueTask<User> CreateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        user.Id = Guid.NewGuid();

        return _userRepository.CreateAsync(user, saveChanges, cancellationToken);
    }

    public ValueTask<User> UpdateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default) =>
        _userRepository.UpdateAsnc(user, saveChanges, cancellationToken);

    public ValueTask<User> DeleteByIdAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default) =>
        _userRepository.DeleteByIdAsnc(id, saveChanges, cancellationToken);

    public ValueTask<User> DeleteAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default) =>
        _userRepository.DeleteAsync(user, saveChanges, cancellationToken);
}