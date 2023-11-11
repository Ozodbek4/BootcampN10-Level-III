using N70.Identity.Application.Common.Identity.Services;
using N70.Identity.Domain.Entities;

namespace N70.Identity.Infrastructure.Common.Identity.Services;

public class UserService : IUserService
{
    public ValueTask<User> CreateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public ValueTask<User> DeleteAsync(Guid id, bool saveChanges, CancellationToken cancellationToken = default)
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

    public ValueTask<User> UpdateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}