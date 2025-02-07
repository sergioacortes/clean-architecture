using CleanArchitecture.Orders.Domain.Base;
using CleanArchitecture.Orders.Domain.Companies.Entities;

namespace CleanArchitecture.Orders.Domain.Companies.Repositories;

public interface ICompaniesRepository : IDomainRepository<Company, Guid>
{
}