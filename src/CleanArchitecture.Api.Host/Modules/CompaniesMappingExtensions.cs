using CleanArchitecture.Orders.Application.UseCases.Companies;
using CleanArchitecture.Orders.Domain.Companies.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Api.Host.Modules;

internal static class CompaniesMappingExtensions
{

    internal static void MapCompaniesEndpoints(this IEndpointRouteBuilder app)
    {
        
        app.MapGet("/api/companies", async ([FromServices]ICompaniesDomainRepository companiesRepository) =>
            {
                var companies = await companiesRepository.GetAllAsync(CancellationToken.None).ConfigureAwait(false);
                return Results.Ok(companies);
            })
            .WithName("CompanyGetAll");

        app.MapPost("/api/companies", async ([FromServices]IMediator mediator, [FromBody]CreateCompanyRequest request) =>
            {
                var response = await mediator.Send(request);
                return Results.Ok(response);
            })
            .WithName("CompanyCreate");
        
    }

}