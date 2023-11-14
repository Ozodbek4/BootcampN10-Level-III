using N70.Identity.Application.Common.Identity.Services;
using N70.Identity.Domain.Entities;
using N70.Identity.Persistence.Repositories.Interfaces;
using System.Linq.Expressions;

namespace N70.Identity.Infrastructure.Common.Identity.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository) =>
        _userRepository = userRepository;

    public ValueTask<User> Get(Expression<Func<bool>>? predicate = null, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public ValueTask<User?> GetByEmailAddress(string emailAddress, bool asNoTracking = false, bool cancellationToken = false)
    {
        throw new NotImplementedException();
    }

    public ValueTask<User?> GetByIdAsync(Guid id, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async ValueTask<User> CreateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default) =>
        await _userRepository.CreateAsync(user, saveChanges, cancellationToken);

    public ValueTask<User> UpdateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public ValueTask<User> DeleteAsync(Guid id, bool saveChanges, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}