using CleanArchitecture.Application.Companies.CreateCompany;
using CleanArchitecture.Application.Extensions;
using CleanArchitecture.Infrastructure.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services
    .AddPersistence(builder.Configuration)
    .AddApplication();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapPost("/api/companies", async ([FromServices]IMediator mediator, [FromBody]CreateCompanyRequest request) =>
{
    var result = await mediator.Send(request);
    return Results.Ok(result);
});
    
await app.RunAsync();

namespace CleanArchitecture.Api.Host
{
    public class Program
    {
    }
}