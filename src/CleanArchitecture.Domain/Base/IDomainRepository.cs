namespace CleanArchitecture.Domain.Base;

public interface IDomainRepository<TEntity, TKey> : IDomainQueryRepository<TEntity, TKey>
    where TEntity : DomainEntity<TKey>
{
    Task AddAsync(TEntity entity, CancellationToken cancellationToken);
    void UpdateAsync(TEntity entity);
    void RemoveAsync(TEntity entity);
    Task SaveChangesAsync(CancellationToken cancellationToken);
}