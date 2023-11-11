using N70.Identity.Domain.Entities;

namespace N70.Identity.Application.Common.Identity.Services;

public interface IAccessTokenService
{
    public ValueTask<AccessToken> CreateAsync(Guid userId, string value, bool saveChanges = true, CancellationToken cancellationToken = default);
}