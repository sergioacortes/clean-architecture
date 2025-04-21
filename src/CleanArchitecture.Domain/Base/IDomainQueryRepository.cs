using System.Linq.Expressions;

namespace CleanArchitecture.Domain.Base;

public interface IDomainQueryRepository<TEntity, TKey>
    where TEntity : DomainEntity<TKey>
{
    Task<IEnumerable<TEntity>> GetAsync(CancellationToken cancellationToken);
    Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);
    Task<TEntity> GetAsync(TKey id, CancellationToken cancellationToken);
}