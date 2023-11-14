using Microsoft.EntityFrameworkCore;
using N70.Identity.Domain.Entities;
using N70.Identity.Persistence.Repositories.Interfaces;
using System.Linq.Expressions;

namespace N70.Identity.Persistence.Repositories;

public class RoleRepository : EntityRepositoryBase<Role, DbContext>, IRoleRepository
{
    public RoleRepository(DbContext dbContext) : base(dbContext)
    {
    }

    public IQueryable<Role> Get(Expression<Func<Role, bool>>? predicate = default, bool asNoTracking = default)
    {
        throw new NotImplementedException();
    }
}