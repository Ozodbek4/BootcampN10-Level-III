using N70.Identity.Application.Common.Identity.Models;
using N70.Identity.Application.Common.Identity.Services;

namespace N70.Identity.Infrastructure.Common.Identity.Services;

public class AuthService : IAuthService
{
    public ValueTask<string> LoginAsync(LoginDetails loginDetails)
    {
        throw new NotImplementedException();
    }

    public ValueTask<bool> RegisterAsync(RegisterDetails registerDetails)
    {
        throw new NotImplementedException();
    }
}