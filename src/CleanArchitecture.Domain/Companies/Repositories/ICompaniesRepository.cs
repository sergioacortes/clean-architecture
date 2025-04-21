using CleanArchitecture.Domain.Base;

namespace CleanArchitecture.Domain.Companies.Repositories;

public interface ICompaniesRepository : IDomainRepository<Company, Guid>;