using Asp.Versioning.Builder;
using Asp.Versioning.Conventions;
using CleanArchitecture.Application.Companies.CreateCompany;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Api.Host.Routes;

public class CompaniesEndpointsRegister : IEndpointsRegister
{
    public void MapEndpoints(IEndpointRouteBuilder endpointRouteBuilder)
    {

        ApiVersionSet apiVersionSet = endpointRouteBuilder
            .NewApiVersionSet()
            .HasApiVersion(2)
            .HasDeprecatedApiVersion(1)
            .ReportApiVersions()
            .Build();

        RouteGroupBuilder routenGroupBuilder = endpointRouteBuilder
            .MapGroup("/api/v{apiVersion:apiVersion}")
            .WithApiVersionSet(apiVersionSet);
        
        routenGroupBuilder
            .MapPost("/api/v{apiVersion:apiVersion}/companies",
                async ([FromServices] IMediator mediator, [FromBody] CreateCompanyRequest request) =>
                {
                    var result = await mediator.Send(request);
                    return Results.Ok(result);
                });
        
    }
}