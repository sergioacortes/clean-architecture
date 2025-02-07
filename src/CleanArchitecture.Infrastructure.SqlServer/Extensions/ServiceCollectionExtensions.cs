using CleanArchitecture.Orders.Domain.Companies.Repositories;
using CleanArchitecture.Orders.Infrastructure.SqlServer.Companies.Repositories;
using CleanArchitecture.Orders.Infrastructure.SqlServer.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Orders.Infrastructure.SqlServer.Extensions;

public static class ServiceCollectionExtensions 
{

    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {

        var systemConnectionStrng = configuration.GetConnectionString("SystemConnection");
        
        services.AddDbContext<SystemDbContext>(opts => 
            opts.UseSqlServer(systemConnectionStrng)
        );

        services.AddScoped<ICompaniesRepository, CompaniesRepository>();
        
        return services;
        
    }
    
}