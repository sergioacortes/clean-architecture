using MediatR;

namespace CleanArchitecture.Application.Companies.CreateCompany;

public record CreateCompanyRequest(string TradeName) : IRequest<CreateCompanyResponse>;