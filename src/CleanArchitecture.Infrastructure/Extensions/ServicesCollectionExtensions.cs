using CleanArchitecture.Domain.Companies.Repositories;
using CleanArchitecture.Infrastructure.Comapnies.Repositories;
using CleanArchitecture.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Infrastructure.Extensions;

public static class ServicesCollectionExtensions
{
    
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {

        var systemDbConnectionString = configuration.GetConnectionString("SystemDbConnectionString") ??
                                       throw new ArgumentNullException(nameof(configuration));

        services.AddDbContext<SystemDbContext>(builder =>
        {
            builder.UseSqlServer(systemDbConnectionString, options =>
            {
                options.MigrationsAssembly(typeof(SystemDbContext).Assembly.FullName);
                options.MigrationsHistoryTable($"{HistoryRepository.DefaultTableName}", $"{SystemDbContext.Schema}");
            });
        });
        
        services.AddDbContext<SystemQueryDbContext>(builder =>
        {
            builder.UseSqlServer(systemDbConnectionString, options =>
            {
                options.MigrationsAssembly(typeof(SystemQueryDbContext).Assembly.FullName);
                options.MigrationsHistoryTable($"{HistoryRepository.DefaultTableName}", $"{SystemDbContext.Schema}");
            });
            builder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        });

        services.AddScoped<ICompaniesQueryRepository, CompaniesQueryRepository>();
        services.AddScoped<ICompaniesRepository, CompaniesRepository>();
        
        return services;
    }

}