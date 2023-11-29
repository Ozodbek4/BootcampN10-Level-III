using Interceptor.Application.Common.Services;
using Interceptor.Domain.Entities;
using Interceptor.Persistence.Repository.Interfaces;
using System.Linq.Expressions;

namespace Interceptor.Infrastructure.Common.Services;

public class UserService(IUserRepository userRepository) : IUserService
{
    public IQueryable<User> Get(Expression<Func<User, bool>> predicate, bool asNoTracking = false, CancellationToken cancellationToken = default) =>
        userRepository.Get(predicate, asNoTracking, cancellationToken);

    public ValueTask<User?> GetByIdAsync(Guid id, bool asNoTracking = false, CancellationToken cancellationToken = default) =>
        userRepository.GetByIdAsync(id, asNoTracking, cancellationToken);

    public ValueTask<IList<User>> GetByIdsAsync(IEnumerable<Guid> ids, bool asNoTracking = false, CancellationToken cancellationToken = default) =>
        userRepository.GetByIdsAsync(ids, asNoTracking, cancellationToken);

    public ValueTask<User> CreateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        user.Id = Guid.Empty;

        return userRepository.CreateAsync(user, saveChanges, cancellationToken);
    }

    public ValueTask<User> UpdateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default) =>
        userRepository.UpdateAsync(user, saveChanges, cancellationToken);

    public ValueTask<User> DeleteAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default) =>
        userRepository.DeleteAsync(user, saveChanges, cancellationToken);

    public ValueTask<User> DeleteByIdAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default) =>
        userRepository.DeleteByIdAsync(id, saveChanges, cancellationToken);

    public ValueTask<IList<User>> DeleteByIdsAsync(IEnumerable<Guid> ids, bool saveChanges = true, CancellationToken cancellationToken = default) =>
        userRepository.DeleteByIdsAsync(ids, saveChanges, cancellationToken);
}