using System.Linq.Expressions;
using CleanArchitecture.Domain.Base;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Contexts;

public abstract class DomainQueryRepository<TEntity, TKey>(DbContext dbContext) : IDomainQueryRepository<TEntity, TKey>
    where TEntity : DomainEntity<TKey>
{
    public async Task<IEnumerable<TEntity>> GetAsync(CancellationToken cancellationToken) =>
        await GetSet().ToListAsync(cancellationToken);

    public async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return await GetSet().Where(predicate).ToListAsync(cancellationToken);
    }

    public async Task<TEntity> GetAsync(TKey id, CancellationToken cancellationToken) =>
        await GetSet().FindAsync(id, cancellationToken);

    protected DbSet<TEntity> GetSet() => dbContext.Set<TEntity>();
}