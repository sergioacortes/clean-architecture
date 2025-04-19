using CleanArchitecture.Application.Companies.CreateCompany;
using MediatR;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapPost("/api/companies", async ([FromServices]IMediator mediator, [FromBody]CreateCompanyRequest request) =>
{
    await mediator.Send(request);
    return Results.Ok();
});
    
await app.RunAsync();

namespace CleanArchitecture.Api.Host
{
    public class Program
    {
    }
}