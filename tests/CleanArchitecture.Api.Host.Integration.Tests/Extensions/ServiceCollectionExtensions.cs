using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Api.Host.Integration.Tests.Extensions;

public static class ServiceCollectionExtensions
{

    public static void ApplyEntityFrameworkMigrations<T>(this IServiceCollection services)
        where T : DbContext
    {
        using var scope = services.BuildServiceProvider().CreateScope();
        var serviceProvider = scope.ServiceProvider;
        var context = serviceProvider.GetRequiredService<T>();
        context.Database.EnsureCreated();
    }
    
}