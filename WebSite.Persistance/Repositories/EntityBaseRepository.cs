using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebSite.Domain.Common.Entity;


namespace WebSite.Persistance.Repositories;
public abstract class EntityBaseRepository<TEntity, TContext>(TContext dbContext ) 
    where TEntity : class, IEntity where TContext : DbContext
{
    protected TContext DbContext => dbContext;

    private DbSet<TEntity> _dbSet => DbContext.Set<TEntity>();

    protected IQueryable<TEntity> Get(Expression<Func<TEntity, bool>>? predicate = default, bool asNoTracking = true)
    {
        var query = _dbSet.AsQueryable();

        if (predicate is not null)
        {
            query = query.Where(predicate);
        }

        if (asNoTracking)
        {
            query = query.AsNoTracking();
        }

        return query;
    }
    protected async ValueTask<IList<TEntity>> GetAsync(bool asNoTracking = true, CancellationToken cancellationToken = default)
    {
        var initialQuery = _dbSet.AsQueryable();
        if (asNoTracking)
        {
            initialQuery = initialQuery.AsNoTracking();
        }
        var foundEntites = await initialQuery.ToListAsync();
        return foundEntites;

    }
    protected async ValueTask<TEntity?> GetByIdAsync(Guid id, bool asNoTracking = true, CancellationToken cancellationToken = default)
    {
        var foundEntity = default(TEntity?);

        var initialQuery = _dbSet.AsQueryable();

        if (asNoTracking)
        {
            initialQuery = initialQuery.AsNoTracking();
        }

        foundEntity = await initialQuery.FirstOrDefaultAsync(entity => entity.Id == id, cancellationToken);
        return foundEntity;
    }
    protected async ValueTask<IList<TEntity>> GetByIdsAsync(IEnumerable<Guid> ids, bool asNoTracking = true, CancellationToken cancellationToken = default)
    {
        var foundEntity = default(TEntity?);
        var initialQuery = _dbSet.AsQueryable().Where(entity => true);


        if (asNoTracking) initialQuery = initialQuery.AsNoTracking();

        initialQuery = initialQuery.Where(entity => ids.Contains(entity.Id));

        return await initialQuery.ToListAsync(cancellationToken);
    }
    protected async ValueTask<TEntity> CreateAsync(TEntity entity, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        await _dbSet.AddAsync(entity, cancellationToken);
        if (saveChanges)
        {
            await DbContext.SaveChangesAsync(cancellationToken);
        }

        return entity;
    }
    protected async ValueTask<TEntity> UpdateAsync(TEntity entity, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        _dbSet.Update(entity);
        if (saveChanges)
        {
            await DbContext.SaveChangesAsync(cancellationToken);
        }

        return entity;

    }
    protected async ValueTask<TEntity> DeleteAsync(TEntity entity, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        _dbSet.Remove(entity);
        if (saveChanges)
        {
            await DbContext.SaveChangesAsync(cancellationToken);
        }

        return entity;
    }
    protected async ValueTask<TEntity> DeleteByIdAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default)
    {

        var deleted = await _dbSet.FirstOrDefaultAsync(entity => entity.Id == id, cancellationToken) ??
            throw new ArgumentException();
        _dbSet.Remove(deleted);
        if (saveChanges)
        {
            await DbContext.SaveChangesAsync(cancellationToken);
        }

        return deleted;
    }

}
