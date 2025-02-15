using MediatR;

namespace CleanArchitecture.Orders.Application.UseCases.Companies;

public record CreateCompanyRequest(string TenantId, string TradeName) : IRequest<CreateCompanyResponse>;