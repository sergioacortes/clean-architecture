using CleanArchitecture.Orders.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Orders.Application.Extensions;

public static class ApplicationExtensions
{
    
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        
        services.AddScoped<ApplicationService>();
        
        return services;
    }
    
    
}