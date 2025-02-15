using CleanArchitecture.Orders.Domain.Companies.Entities;
using CleanArchitecture.Orders.Domain.Companies.Repositories;
using CleanArchitecture.Orders.Domain.Databases.Repositories;
using MediatR;

namespace CleanArchitecture.Orders.Application.UseCases.Companies;

public class CreateCompanyHandler(ICompaniesDomainRepository companiesDomainRepository, IDatabasesDomainRepository databasesDomainRepository) : IRequestHandler<CreateCompanyRequest, CreateCompanyResponse>
{
    public async Task<CreateCompanyResponse> Handle(CreateCompanyRequest request, CancellationToken cancellationToken)
    {
        var currentDatabaseId = await GetCurrentDatabase(cancellationToken).ConfigureAwait(false);
        var company = Company.Create(request.TenantId, request.TradeName, Guid.NewGuid());
        await companiesDomainRepository.AddAsync(company, cancellationToken).ConfigureAwait(false);
        await companiesDomainRepository.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        return new CreateCompanyResponse(company.Id, company.TenantId, company.TradeName); 
    }

    private async Task<Guid> GetCurrentDatabase(CancellationToken cancellationToken)
    {
        
        var databases = await databasesDomainRepository.GetAsync(r => r.IsActive, cancellationToken).ConfigureAwait(false);
        var currentDatabase = databases.First();

        return currentDatabase.Id;

    }
    
}