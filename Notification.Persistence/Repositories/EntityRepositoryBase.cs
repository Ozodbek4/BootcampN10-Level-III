using Microsoft.EntityFrameworkCore;
using Notification.Domain.Common.Entities;
using System.Linq.Expressions;

namespace Notification.Persistence.Repositories;

public abstract class EntityRepositoryBase<TEntity, TContext> where TEntity : class, IEntity where TContext : DbContext
{
    protected TContext DbContext => _dbContext;
    private readonly TContext _dbContext;

    public EntityRepositoryBase(TContext dbContext)
    {
        _dbContext = dbContext;
    }

    protected IQueryable<TEntity> Get(Expression<Func<TEntity, bool>>? predicate = default, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        var initalQuery = DbContext.Set<TEntity>().Where(entiy => true);

        if (predicate is not null)
            initalQuery = initalQuery.Where(predicate);

        if (asNoTracking)
            initalQuery.AsNoTracking();

        return initalQuery;
    }

    protected async ValueTask<TEntity?> GetByIdAsync(Guid id, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        var initialQuery = DbContext.Set<TEntity>().Where(entity => true);

        if (asNoTracking)
            initialQuery = initialQuery.AsNoTracking();

        return await initialQuery.SingleOrDefaultAsync(entity => entity.Id == id, cancellationToken: cancellationToken);
    }

    protected async ValueTask<IList<TEntity>> GetByIdsAsync(IEnumerable<Guid> ids, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        var initialQuery = DbContext.Set<TEntity>().Where(entity => true);

        if (asNoTracking)
            initialQuery = initialQuery.AsNoTracking();

        initialQuery = initialQuery.Where(entity => ids.Contains(entity.Id));

        return await initialQuery.ToListAsync(cancellationToken: cancellationToken);
    }

    protected async ValueTask<TEntity> CreateAsync(TEntity entity, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        entity.Id = Guid.Empty;

        await DbContext.Set<TEntity>().AddAsync(entity, cancellationToken: cancellationToken);

        if (saveChanges)
            await DbContext.SaveChangesAsync(cancellationToken: cancellationToken);

        return entity;
    }

    protected async ValueTask<TEntity> UpdateAsnc(TEntity entity, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        DbContext.Update(entity);

        if (saveChanges)
            await DbContext.SaveChangesAsync(cancellationToken: cancellationToken);

        return entity;
    }

    protected async ValueTask<TEntity> DeleteAsync(TEntity entity, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        DbContext.Remove(entity);

        if (saveChanges)
            await DbContext.SaveChangesAsync(cancellationToken: cancellationToken);

        return entity;
    }

    protected async ValueTask<TEntity> DeleteByIdAsnc(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var deleted = await GetByIdAsync(id, true, cancellationToken) ?? throw new InvalidOperationException();

        DbContext.Remove(deleted);

        if (saveChanges)
            await DbContext.SaveChangesAsync();

        return deleted;
    }
}