using Microsoft.EntityFrameworkCore;
using N70.Identity.Domain.Entities;
using N70.Identity.Persistence.Repositories.Interfaces;

namespace N70.Identity.Persistence.Repositories;

public class AccessTokenRepository : EntityRepositoryBase<AccessToken, DbContext>, IAccessTokenRepository
{
    public AccessTokenRepository(DbContext context) : base(context)
    {
    }

    public new async ValueTask<AccessToken> CreateAsync(AccessToken token, bool saveChanges = true, CancellationToken cancellationToken = default) =>
        await base.CreateAsync(token, saveChanges, cancellationToken);
}