using N70.Identity.Domain.Entities;
using N70.Identity.Persistence.DataContext;
using N70.Identity.Persistence.Repositories.Interfaces;
using System.Linq.Expressions;

namespace N70.Identity.Persistence.Repositories;

public class RoleRepository : EntityRepositoryBase<Role, AppDbContext>, IRoleRepository
{
    public RoleRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public IQueryable<Role?> Get(Expression<Func<Role, bool>>? predicate = default, bool asNoTracking = default) =>
        base.Get(predicate, asNoTracking);
}