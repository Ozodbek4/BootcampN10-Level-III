using Blog.Application.Services;
using Blog.Domain.Entities;
using Blog.Persistence.Repositories.Interfaces;

namespace Blog.Infrastructure.Services;

public class UserService(IUserRepository userRepository) : IUserService
{
    public ValueTask<IList<User>> GetAllAsync(bool asNoTracking = false) =>
        userRepository.GetAllAsync(asNoTracking);
    
    public ValueTask<User?> GetByIdAsync(Guid id, bool asNoTracking = false, CancellationToken cancellationToken = default) =>
        userRepository.GetByIdAsync(id, asNoTracking, cancellationToken);

    public ValueTask<User> CreateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default) =>
        userRepository.CreateAsync(user, saveChanges, cancellationToken);

    public ValueTask<User> UpdateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default) =>
        userRepository.UpdateAsync(user, saveChanges, cancellationToken);

    public ValueTask<User> DeleteByIdAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default) =>
        userRepository.DeleteByIdAsync(id, saveChanges, cancellationToken);
}