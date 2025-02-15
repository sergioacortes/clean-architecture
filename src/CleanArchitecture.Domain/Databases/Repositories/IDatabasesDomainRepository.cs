using CleanArchitecture.Orders.Domain.Base;
using CleanArchitecture.Orders.Domain.Databases.Entities;

namespace CleanArchitecture.Orders.Domain.Databases.Repositories;

public interface IDatabasesDomainRepository : IDomainRepository<Database, Guid>
{
}