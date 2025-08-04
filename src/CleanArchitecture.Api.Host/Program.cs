using System.Reflection;
using CleanArchitecture.Api.Host.Extensions;
using CleanArchitecture.Application.Extensions;
using CleanArchitecture.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerOpenApi();

var assembly = Assembly.GetExecutingAssembly();

builder.Services
    .AddPersistence(builder.Configuration)
    .AddApplication()
    .AddEndpointsRegisters(assembly);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseSwaggerOpenApi();
app.UseEndpointsRegisters();

await app.RunAsync();

public partial class Program
{
}