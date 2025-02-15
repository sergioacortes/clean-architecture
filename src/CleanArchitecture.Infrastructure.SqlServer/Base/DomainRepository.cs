using System.Linq.Expressions;
using CleanArchitecture.Orders.Domain.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace CleanArchitecture.Orders.Infrastructure.SqlServer.Base;

public abstract class DomainRepository<TEntity, TKey>(DbContext context) : IDomainRepository<TEntity, TKey>
    where TEntity : DomainEntity<TKey>
{
    
    public async Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await GetDbSet().ToListAsync(cancellationToken).ConfigureAwait(false);
    }
    
    public async Task<TEntity> GetAsync(TKey id, CancellationToken cancellationToken)
    {
        var entity = await GetDbSet().FindAsync(id, cancellationToken).ConfigureAwait(false);
        return entity!;
    }

    public async Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken)
    {

        if (filter is null)
        {
            throw new ArgumentNullException(nameof(filter), $"The argument {nameof(filter)} cannot be null.");
        }

        return await GetDbSet()
            .Where(filter)
            .ToListAsync(cancellationToken).ConfigureAwait(false);
    }
    
    public async Task<List<TResult>> GetAsync<TResult>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TResult>> selector, CancellationToken cancellationToken)
    {

        if (filter is null)
        {
            throw new ArgumentNullException(nameof(filter), $"The argument {nameof(filter)} cannot be null.");
        }

        if (selector is null)
        {
            throw new ArgumentNullException(nameof(selector), $"The argument {nameof(selector)} cannot be null.");
        }

        return await GetDbSet()
            .Where(filter)
            .Select(selector)
            .ToListAsync(cancellationToken).ConfigureAwait(false);
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

    public async Task ExecuteUpdateAsync(Expression<Func<TEntity, bool>> filter, Expression<Func<SetPropertyCalls<TEntity>, SetPropertyCalls<TEntity>>> setPropertyCalls,
        CancellationToken cancellationToken = default)
    {

        if (filter is null)
        {
            throw new ArgumentNullException(nameof(filter), $"The argument {nameof(filter)} cannot be null.");
        }
        
        await GetDbSet()
            .Where(filter)
            .ExecuteUpdateAsync(setPropertyCalls, cancellationToken).ConfigureAwait(false);
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