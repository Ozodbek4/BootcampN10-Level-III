using N70.Identity.Domain.Entities;

namespace N70.Identity.Application.Common.Identity.Services;

public interface IAccountService
{
    ValueTask<bool> VerificationAsync(User user);

    ValueTask<User> CreateUserAsync(User user);
}