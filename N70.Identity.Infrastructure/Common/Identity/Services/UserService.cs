﻿using N70.Identity.Application.Common.Identity.Services;
using N70.Identity.Domain.Entities;
using N70.Identity.Persistence.Repositories.Interfaces;
using System.Linq.Expressions;

namespace N70.Identity.Infrastructure.Common.Identity.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository) =>
        _userRepository = userRepository;

    public ValueTask<IEnumerable<User?>> Get(Expression<Func<User, bool>>? predicate = default, bool asNoTracking = false, CancellationToken cancellationToken = default) =>
        new (_userRepository.Get(predicate, asNoTracking, cancellationToken));

    public ValueTask<User?> GetByIdAsync(Guid id, bool asNoTracking = false, CancellationToken cancellationToken = default) =>
        _userRepository.GetByIdAsync(id, asNoTracking, cancellationToken);

    public async ValueTask<User> CreateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default) =>
        await _userRepository.CreateAsync(user, saveChanges, cancellationToken);

    public ValueTask<User> UpdateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default) =>
        _userRepository.UpdateAsync(user, saveChanges, cancellationToken);

    public ValueTask<User> DeleteAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default) =>
        _userRepository.DeleteByIdAsync(id, saveChanges, cancellationToken);
}