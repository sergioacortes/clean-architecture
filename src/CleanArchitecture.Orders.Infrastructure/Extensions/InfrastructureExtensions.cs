using CleanArchitecture.Orders.Infrastructure.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Orders.Infrastructure.Extensions;

public static class InfrastructureExtensions
{

    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        
        /*
        
        var options = configuration
            .GetSection(ConfigurationOptions.SectionName)
            .Get<ConfigurationOptions>();

        services.AddScoped<ConfigurationOptions>(x => options);
        
        */

        services
            .Configure<ConfigurationOptions>(
                configuration.GetSection(ConfigurationOptions.SectionName)
            );
        
        return services;
    }
    
}