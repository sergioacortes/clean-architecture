using CleanArchitecture.Domain.Companies;
using CleanArchitecture.Domain.Companies.Repositories;
using CleanArchitecture.Infrastructure.Contexts;

namespace CleanArchitecture.Infrastructure.Comapnies.Repositories;

public class CompaniesRepository(SystemDbContext dbContext) : DomainRepository<Company, Guid>(dbContext), ICompaniesRepository;