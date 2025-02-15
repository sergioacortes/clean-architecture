using CleanArchitecture.BackOffice.Api.Host.Modules;
using CleanArchitecture.Orders.Application.Extensions;
using CleanArchitecture.Orders.Infrastructure.SqlServer.Extensions;

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

app.MapDatabasesEndpoints();

await app.RunAsync();

namespace CleanArchitecture.BackOffice.Api.Host
{
    public class Program
    {
        protected Program()
        {
        }
    }
}