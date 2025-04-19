using CleanArchitecture.Api.Host.Integration.Tests.Extensions;
using CleanArchitecture.Infrastructure.Contexts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Respawn;
using Respawn.Graph;
using Testcontainers.MsSql;
using Xunit;

namespace CleanArchitecture.Api.Host.Integration.Tests;

public class BaseFixture : WebApplicationFactory<Program>, IAsyncLifetime
{
    
    private Respawner _respawner;
    private MsSqlContainer _container { get; } = new MsSqlBuilder()
        .WithImage(
            "mcr.microsoft.com/mssql/server:2022-latest"
        )
        .Build();
    
    public async Task ResetDatabase()
    {
        await _respawner.ResetAsync(_container.GetConnectionString()).ConfigureAwait(false);
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureAppConfiguration(_ => { });
        builder.ConfigureServices(_ => { });
        builder.ConfigureTestServices(services =>
        {
            services.RemoveAll<DbContextOptions<SystemDbContext>>();
            services.AddDbContext<SystemDbContext>(options =>
            {
                options.UseSqlServer(_container.GetConnectionString());
            });
            services.ApplyEntityFrameworkMigrations<SystemDbContext>();
        });
        base.ConfigureWebHost(builder);
    }

    public async Task InitializeAsync()
    {
        await _container.StartAsync();
        _respawner = await Respawner.CreateAsync(_container.GetConnectionString(), new RespawnerOptions()
        {
            DbAdapter = DbAdapter.SqlServer,
            TablesToIgnore = [ new Table("__EFMigrationsHistory") ]
        });
    }
    
    public override async ValueTask DisposeAsync()
    {
        await _container.StopAsync();
        await base.DisposeAsync();
    }

    async Task IAsyncLifetime.DisposeAsync()
    {
        await DisposeAsync();
    }
}