using CleanArchitecture.Orders.Application.UseCases.Databases.RegisterDatabase;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Api.Host.Modules;

public static class DatabasesMappingExtensions
{

    public static void MapDatabasesEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("api/databases", async ([FromServices]IMediator mediator, [FromBody]RegisterDatabaseRequest request) =>
        {
            
            var registeredDatabase = await mediator.Send(request);
            return Results.Ok(registeredDatabase);
            
        });
    }

}