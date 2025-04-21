using CleanArchitecture.Domain.Base;

namespace CleanArchitecture.Domain.Companies.Repositories;

public interface ICompaniesQueryRepository : IDomainQueryRepository<Company, Guid>;