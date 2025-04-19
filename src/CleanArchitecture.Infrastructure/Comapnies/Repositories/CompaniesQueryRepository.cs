using CleanArchitecture.Domain.Companies;
using CleanArchitecture.Domain.Companies.Repositories;
using CleanArchitecture.Infrastructure.Contexts;

namespace CleanArchitecture.Infrastructure.Comapnies.Repositories;

public class CompaniesQueryRepository(SystemQueryDbContext dbContext) : DomainQueryRepository<Company, Guid>(dbContext), ICompaniesQueryRepository;