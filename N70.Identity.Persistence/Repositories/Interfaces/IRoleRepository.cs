using N70.Identity.Domain.Entities;
using System.Linq.Expressions;

namespace N70.Identity.Persistence.Repositories.Interfaces;

public interface IRoleRepository
{
    IQueryable<Role> Get(Expression<Func<Role, bool>>? predicate = default, bool asNoTracking);
}