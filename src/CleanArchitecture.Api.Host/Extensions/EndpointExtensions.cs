using System.Reflection;
using CleanArchitecture.Api.Host.Routes;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace CleanArchitecture.Api.Host.Extensions;

public static class EndpointExtensions
{

    public static IServiceCollection AddEndpointsRegisters(this IServiceCollection services, Assembly assembly)
    {

        ServiceDescriptor[] endpointServiceDescriptors = assembly
            .DefinedTypes
            .Where(type => type is { IsAbstract: false, IsInterface: false } &&
                           type.IsAssignableTo(typeof(IEndpointsRegister))
            )
            .Select(type => ServiceDescriptor.Transient(typeof(IEndpointsRegister), type))
            .ToArray();
        
        services.TryAddEnumerable(endpointServiceDescriptors);
        
        return services;

    }

    public static IApplicationBuilder UseEndpointsRegisters(this WebApplication app)
    {

        IEnumerable<IEndpointsRegister> endPointEndpointsRegisters =
            app.Services.GetRequiredService<IEnumerable<IEndpointsRegister>>();

        foreach (IEndpointsRegister endpointsRegister in endPointEndpointsRegisters)
        {
            endpointsRegister.MapEndpoints(app);
        }

        return app;

    }

}