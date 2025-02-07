using System.Linq.Expressions;

namespace CleanArchitecture.Orders.Domain.Base;

public interface IDomainRepository<TEntity, in TKey> where TEntity : DomainEntity<TKey>
{
    
    Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken);
    
    Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);
    
    Task<TEntity> GetAsync(TKey id, CancellationToken cancellationToken);
    
    Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken);
    
    void Update(TEntity entity);
    
    Task DeleteAsync(TKey id, CancellationToken cancellationToken);
    
    Task SaveChangesAsync(CancellationToken cancellationToken);
    
}