using System.Reflection;
using Asp.Versioning;
using CleanArchitecture.Api.Host.Extensions;
using CleanArchitecture.Application.Extensions;
using CleanArchitecture.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerOpenApi();

builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.ApiVersionReader = ApiVersionReader.Combine(
        new UrlSegmentApiVersionReader(),
        new HeaderApiVersionReader("x-api-version")
    );
})
.AddMvc()
.AddApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
});

var assembly = Assembly.GetExecutingAssembly();

builder.Services
    .AddPersistence(builder.Configuration)
    .AddApplication()
    .AddEndpointsRegisters(assembly);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    // app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseSwaggerOpenApi();
app.UseEndpointsRegisters();

await app.RunAsync();

public partial class Program
{
}