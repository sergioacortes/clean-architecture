using CleanArchitecture.Domain.Companies;
using CleanArchitecture.Domain.Companies.Repositories;
using MediatR;

namespace CleanArchitecture.Application.Companies.CreateCompany;

public class CreateCompanyHandler(ICompaniesRepository companiesRepository) : IRequestHandler<CreateCompanyRequest, CreateCompanyResponse>
{
    public async Task<CreateCompanyResponse> Handle(CreateCompanyRequest request, CancellationToken cancellationToken)
    {
        var company = Company.Create(request.TradeName);
        await companiesRepository.AddAsync(company, cancellationToken);
        await companiesRepository.SaveChangesAsync(cancellationToken);

        return new CreateCompanyResponse(company.Id, company.TradeName);
    }
}