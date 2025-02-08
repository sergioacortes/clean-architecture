using CleanArchitecture.Orders.Application.Extensions;
using CleanArchitecture.Orders.Application.UseCases.Companies;
using CleanArchitecture.Orders.Domain.Companies.Repositories;
using CleanArchitecture.Orders.Infrastructure.SqlServer.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services
    .AddApplication()
    .AddPersistence(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/api/companies", async ([FromServices]ICompaniesRepository companiesRepository) =>
    {
        var companies = await companiesRepository.GetAllAsync(CancellationToken.None).ConfigureAwait(false);
        return companies;
    })
    .WithName("CompanyGetAll");

app.MapPost("/api/companies", async ([FromServices]IMediator mediator, [FromBody]CreateCompanyRequest request) =>
    {
        var response = await mediator.Send(request);
        return response;
    })
    .WithName("CompanyCreate");

await app.RunAsync();

namespace CleanArchitecture.Api.Host
{
    public class Program
    {
        protected Program()
        {
        }
    }
}