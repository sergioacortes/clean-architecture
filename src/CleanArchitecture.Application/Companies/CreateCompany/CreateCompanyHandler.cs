using MediatR;

namespace CleanArchitecture.Application.Companies.CreateCompany;

public class CreateCompanyHandler : IRequestHandler<CreateCompanyRequest, CreateCompanyResponse>
{
    public Task<CreateCompanyResponse> Handle(CreateCompanyRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}