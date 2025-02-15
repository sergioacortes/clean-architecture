using CleanArchitecture.Orders.Domain.Base;
using CleanArchitecture.Orders.Domain.Companies.Entities;

namespace CleanArchitecture.Orders.Domain.Companies.Repositories;

public interface ICompaniesDomainRepository : IDomainRepository<Company, Guid>
{
}