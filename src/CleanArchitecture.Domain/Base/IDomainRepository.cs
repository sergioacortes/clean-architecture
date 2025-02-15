using System.Linq.Expressions;

namespace CleanArchitecture.Orders.Domain.Base;

public interface IDomainRepository<TEntity, in TKey> where TEntity : DomainEntity<TKey>
{
    
    Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken);
    
    Task<TEntity> GetAsync(TKey id, CancellationToken cancellationToken);

    Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken);

    Task<List<TResult>> GetAsync<TResult>(Expression<Func<TEntity, bool>> filter,
        Expression<Func<TEntity, TResult>> selector, CancellationToken cancellationToken);

    Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken);
    
    void Update(TEntity entity);
    
    Task DeleteAsync(TKey id, CancellationToken cancellationToken);
    
    Task SaveChangesAsync(CancellationToken cancellationToken);
    
}