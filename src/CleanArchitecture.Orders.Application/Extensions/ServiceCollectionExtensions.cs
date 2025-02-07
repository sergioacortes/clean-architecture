using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Orders.Application.Extensions;

public static class ServiceCollectionExtensions
{
    
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {

        var currentAssembly = typeof(ServiceCollectionExtensions).Assembly;
        
        services.AddMediatR(cfg =>
        {
            //workaround  https://github.com/jbogard/MediatR/issues/1038
            cfg.TypeEvaluator = x => !x.ContainsGenericParameters;
            cfg.RegisterServicesFromAssembly(currentAssembly);
        });
        
        return services;
    }
    
}