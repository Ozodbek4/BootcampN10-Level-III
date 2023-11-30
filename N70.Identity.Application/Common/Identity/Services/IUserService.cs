﻿using N70.Identity.Domain.Entities;
using System.Linq.Expressions;

namespace N70.Identity.Application.Common.Identity.Services;

public interface IUserService
{
    public ValueTask<IEnumerable<User>> Get(Expression<Func<User, bool>>? predicate = default, bool asNoTracking = false, CancellationToken cancellationToken = default);

    public ValueTask<User?> GetByIdAsync(Guid id, bool asNoTracking = false, CancellationToken cancellationToken = default);
    
    public ValueTask<User> CreateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default);

    public ValueTask<User> UpdateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default);

    public ValueTask<User> DeleteAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default);
}