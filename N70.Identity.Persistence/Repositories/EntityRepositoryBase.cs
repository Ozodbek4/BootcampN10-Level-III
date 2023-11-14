using Microsoft.EntityFrameworkCore;
using N70.Identity.Domain.Common;
using System.Linq.Expressions;

namespace N70.Identity.Persistence.Repositories;

public abstract class EntityRepositoryBase<TEntity, TContext> where TEntity : class, IEntity where TContext : DbContext
{
    protected TContext DbContext => (TContext)_dbContext;
    private readonly DbContext _dbContext;

    protected EntityRepositoryBase(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    protected IQueryable<TEntity?> Get(Expression<Func<TEntity, bool>>? predicate, bool asNoTracking, CancellationToken cancellationToken)
    {
        var initialQuery = DbContext.Set<TEntity>().Where(predicate!);

        if (asNoTracking)
            initialQuery.AsNoTracking();

        return initialQuery;
    }

    protected async ValueTask<TEntity?> GetById(Guid id, bool asNoTracking, CancellationToken cancellationToken)
    {
        var initialQuery = DbContext.Set<TEntity>().Where(entity => entity.Id == id);

        if(asNoTracking)
            initialQuery.AsNoTracking();

        return  await initialQuery.SingleOrDefaultAsync(cancellationToken);
    }

    protected async ValueTask<IList<TEntity>> GetByIds(IEnumerable<Guid> ids, bool asNoTracking = false, CancellationToken cancellationToken)
    {
        var initialQuery = DbContext.Set<TEntity>();

        if(asNoTracking)
            initialQuery.AsNoTracking();

        return await initialQuery
            .Where(entity => ids.Contains(entity.Id))
            .ToListAsync(cancellationToken);
    }

    protected async ValueTask<TEntity> CreateAsync(TEntity entity, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        await DbContext.Set<TEntity>().AddAsync(entity, cancellationToken);

        if(saveChanges)
            await DbContext.SaveChangesAsync(cancellationToken);

        return entity;
    }

    protected async ValueTask<TEntity> UpdateAsnyc(TEntity entity, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        DbContext.Set<TEntity>().Update(entity);

        if(saveChanges)
            await DbContext.SaveChangesAsync(cancellationToken);

        return entity;
    }

    protected async ValueTask<TEntity> DeleteAsync(TEntity entity, bool saveChanges = true, CancellationToken cancellationToken)
    {
        DbContext.Set<TEntity>().Remove(entity);

        if(saveChanges)
            await DbContext.SaveChangesAsync(cancellationToken);

        return entity;
    }

    protected async ValueTask<TEntity> DeleteByIdAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var initialQuery = DbContext.Set<TEntity>();

        var tEntity = initialQuery.FirstOrDefault(entity => entity.Id == id) ??
            throw new ArgumentNullException("Entity does not exists");

        initialQuery.Remove(tEntity);

        if (saveChanges)
            await DbContext.SaveChangesAsync(cancellationToken);

        return tEntity;
    }
}