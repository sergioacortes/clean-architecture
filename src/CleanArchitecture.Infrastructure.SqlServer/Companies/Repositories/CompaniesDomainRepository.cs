using CleanArchitecture.Orders.Domain.Companies.Entities;
using CleanArchitecture.Orders.Domain.Companies.Repositories;
using CleanArchitecture.Orders.Infrastructure.SqlServer.Base;
using CleanArchitecture.Orders.Infrastructure.SqlServer.DbContexts;

namespace CleanArchitecture.Orders.Infrastructure.SqlServer.Companies.Repositories;

public class CompaniesDomainRepository(SystemDbContext context) : DomainRepository<Company, Guid>(context), ICompaniesDomainRepository
{
}