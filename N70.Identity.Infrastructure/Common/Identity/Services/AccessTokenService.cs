using N70.Identity.Application.Common.Identity.Services;
using N70.Identity.Domain.Entities;

namespace N70.Identity.Infrastructure.Common.Identity.Services;

public class AccessTokenService : IAccessTokenService
{
    public ValueTask<AccessToken> CreateAsync(Guid userId, string value, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}