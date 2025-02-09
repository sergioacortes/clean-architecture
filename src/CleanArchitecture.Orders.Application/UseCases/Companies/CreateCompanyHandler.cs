using CleanArchitecture.Orders.Domain.Companies.Entities;
using CleanArchitecture.Orders.Domain.Companies.Repositories;
using MediatR;

namespace CleanArchitecture.Orders.Application.UseCases.Companies;

public class CreateCompanyHandler(ICompaniesRepository companiesRepository) : IRequestHandler<CreateCompanyRequest, CreateCompanyResponse>
{
    public async Task<CreateCompanyResponse> Handle(CreateCompanyRequest request, CancellationToken cancellationToken)
    {
        var company = Company.Create(request.TenantId, request.TradeName);
        await companiesRepository.AddAsync(company, cancellationToken);
        await companiesRepository.SaveChangesAsync(cancellationToken);
        return new CreateCompanyResponse(company.Id, company.TenantId, company.TradeName); 
    }
}