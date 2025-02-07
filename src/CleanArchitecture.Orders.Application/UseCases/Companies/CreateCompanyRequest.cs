using MediatR;

namespace CleanArchitecture.Orders.Application.UseCases.Companies;

public record CreateCompanyRequest(string TradeName) : IRequest<CreateCompanyResponse>;