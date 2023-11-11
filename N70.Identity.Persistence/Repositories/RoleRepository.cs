using N70.Identity.Domain.Entities;
using N70.Identity.Persistence.Repositories.Interfaces;
using System.Linq.Expressions;

namespace N70.Identity.Persistence.Repositories;

public class RoleRepository : IRoleRepository
{
    public IQueryable<Role> Get(Expression<Func<Role, bool>> predicate, bool asNoTracking, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}