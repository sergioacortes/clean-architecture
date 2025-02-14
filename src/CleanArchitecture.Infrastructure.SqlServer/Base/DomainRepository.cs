using System.Linq.Expressions;
using CleanArchitecture.Orders.Domain.Base;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Orders.Infrastructure.SqlServer.Base;

public abstract class DomainRepository<TEntity, TKey>(DbContext context) : IDomainRepository<TEntity, TKey>
    where TEntity : DomainEntity<TKey>
{
    
    public async Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await GetDbSet().ToListAsync(cancellationToken).ConfigureAwait(false);
    }

    public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
    {

        if (predicate is null)
        {
            throw new ArgumentNullException(nameof(predicate), $"The argument {nameof(predicate)} cannot be null.");
        }

        return await GetDbSet()
            .Where(predicate)
            .ToListAsync(cancellationToken).ConfigureAwait(false);
    }

    public async Task<TEntity> GetAsync(TKey id, CancellationToken cancellationToken)
    {
        var entity = await GetDbSet().FindAsync(id, cancellationToken).ConfigureAwait(false);
        return entity!;
    }

    public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken)
    {
        await GetDbSet().AddAsync(entity, cancellationToken).ConfigureAwait(false);
        return entity;
    }

    public void Update(TEntity entity)
    {
       GetDbSet().Update(entity);
    }

    public async Task DeleteAsync(TKey id, CancellationToken cancellationToken)
    {
        
        var entity = await GetAsync(id, cancellationToken);

        if (entity is null)
        {
            throw new ArgumentNullException(nameof(id), $"Entity with id {id} was not found");
        }

        GetDbSet().Remove(entity);
        
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
    }

    private DbSet<TEntity> GetDbSet() => context.Set<TEntity>();
    
}