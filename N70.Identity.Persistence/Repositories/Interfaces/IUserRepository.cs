using Microsoft.EntityFrameworkCore;
using N70.Identity.Domain.Entities;
using System.Linq.Expressions;

namespace N70.Identity.Persistence.Repositories.Interfaces;

public interface IUserRepository
{
    IQueryable<User?> Get(Expression<Func<User, bool>> predicate, bool asNoTracking = false, CancellationToken cancellationToken = default);

    ValueTask<User?> GetByIdAsync(Guid id, bool asNoTracking = false, CancellationToken cancellationToken = default);

    ValueTask<IQueryable<User?>> GetAllAsync(bool asNoTracking = false, CancellationToken cancellationToken = default);

    ValueTask<User> CreateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<User> UpdateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken= default);

    ValueTask<User> DeleteByIdAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<User> DeleteAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default);
}