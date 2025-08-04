using CleanArchitecture.Application.Companies.CreateCompany;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Api.Host.Routes;

public class CompaniesEndpointsRegister : IEndpointsRegister
{
    public void MapEndpoints(IEndpointRouteBuilder endpointRouteBuilder)
    {
        endpointRouteBuilder.MapPost("/api/companies", async ([FromServices]IMediator mediator, [FromBody]CreateCompanyRequest request) =>
        {
            var result = await mediator.Send(request);
            return Results.Ok(result);
        });
    }
}