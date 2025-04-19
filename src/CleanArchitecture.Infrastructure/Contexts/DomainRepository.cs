using CleanArchitecture.Domain.Base;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Contexts;

public abstract class DomainRepository<TEntity, TKey>(DbContext dbContext) : DomainQueryRepository<TEntity, TKey>(dbContext), IDomainRepository<TEntity, TKey>
    where TEntity : DomainEntity<TKey>
{
    public async Task AddAsync(TEntity entity, CancellationToken cancellationToken) => 
        await dbContext.AddAsync(entity, cancellationToken);

    public void UpdateAsync(TEntity entity) =>
        dbContext.Update(entity);

    public void RemoveAsync(TEntity entity) =>
        dbContext.Remove(entity);

    public async Task SaveChangesAsync(CancellationToken cancellationToken) =>
        await dbContext.SaveChangesAsync(cancellationToken);
    
}