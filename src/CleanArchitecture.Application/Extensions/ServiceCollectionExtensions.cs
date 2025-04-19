using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Application.Extensions;

public static class ServiceCollectionExtensions
{

    public static IServiceCollection AddApplication(this IServiceCollection services)
    {

        services.AddMediatR(configuration =>
        {
            var assembly = typeof(ServiceCollectionExtensions).Assembly;

            //workaround  https://github.com/jbogard/MediatR/issues/1038
            configuration.TypeEvaluator = x => !x.ContainsGenericParameters;
            configuration.RegisterServicesFromAssembly(assembly);
        });

        return services;
        
    }

}