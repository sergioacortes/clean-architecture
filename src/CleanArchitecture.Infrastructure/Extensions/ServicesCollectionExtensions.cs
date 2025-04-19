using CleanArchitecture.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Infrastructure.Extensions;

public static class ServicesCollectionExtensions
{

    private const string Schema = "System";
    
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<SystemDbContext>(builder =>
        {
            var systemDbConnectionString = configuration.GetConnectionString("SystemDbConnectionString");
            builder.UseSqlServer(systemDbConnectionString, options =>
            {
                options.MigrationsAssembly(typeof(SystemDbContext).Assembly.FullName);
                options.MigrationsHistoryTable($"{HistoryRepository.DefaultTableName}", $"{Schema}");
            });
        });
        return services;
    }

}