using N70.Identity.Application.Common.Identity.Services;
using N70.Identity.Domain.Entities;

namespace N70.Identity.Infrastructure.Common.Identity.Services;

public class AccountService : IAccountService
{
    public ValueTask<User> CreateUserAsync(User user)
    {
        throw new NotImplementedException();
    }

    public ValueTask<bool> VerificationAsync(User user)
    {
        throw new NotImplementedException();
    }
}