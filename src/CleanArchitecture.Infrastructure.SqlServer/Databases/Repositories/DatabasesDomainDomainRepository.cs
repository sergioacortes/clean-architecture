using CleanArchitecture.Orders.Domain.Databases.Entities;
using CleanArchitecture.Orders.Domain.Databases.Repositories;
using CleanArchitecture.Orders.Infrastructure.SqlServer.Base;
using CleanArchitecture.Orders.Infrastructure.SqlServer.DbContexts;

namespace CleanArchitecture.Orders.Infrastructure.SqlServer.Databases.Repositories;

public class DatabasesDomainDomainRepository(SystemDbContext context) : DomainRepository<Database, Guid>(context), IDatabasesDomainRepository
{
}