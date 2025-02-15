using CleanArchitecture.Api.Host.Integration.Tests.Containers;
using CleanArchitecture.Api.Host.Integration.Tests.Extensions;
using CleanArchitecture.Orders.Infrastructure.SqlServer.DbContexts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Respawn;
using Respawn.Graph;
using Xunit;

namespace CleanArchitecture.Api.Host.Integration.Tests;

public class WebApplicationFixture : WebApplicationFactory<Program>, IAsyncLifetime
{
    
    private readonly SqlServerContainer _sqlServerContainer = new();
    
    public SystemDbContext SystemDbContext { get; private set; }
    private Respawner _respawner;
    
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureAppConfiguration(_ => { });
        builder.ConfigureServices(_ => { });
        builder.ConfigureTestServices(services =>
        {
            services.RemoveAll<DbContextOptions<SystemDbContext>>();
            services.AddDbContext<SystemDbContext>(options =>
            {
                options.UseSqlServer(_sqlServerContainer.Container.GetConnectionString());
            });
            services.ApplyEntityFrameworkMigrations<SystemDbContext>();
        });
        base.ConfigureWebHost(builder);
    }

    public async Task InitializeAsync()
    {
        await _sqlServerContainer.Container.StartAsync();

        SystemDbContext = Services.CreateScope().ServiceProvider.GetRequiredService<SystemDbContext>();
        
        _respawner = await Respawner.CreateAsync(_sqlServerContainer.Container.GetConnectionString(), new RespawnerOptions()
        {
            DbAdapter = DbAdapter.SqlServer,
            TablesToIgnore = [ new Table("__EFMigrationsHistory") ]
        });
    }

    public async Task ResetDatabase()
    {
        await _respawner.ResetAsync(_sqlServerContainer.Container.GetConnectionString()).ConfigureAwait(false);
    }
    
    public override async ValueTask DisposeAsync()
    {
        await _sqlServerContainer.Container.DisposeAsync();
        await base.DisposeAsync();
    }

    async Task IAsyncLifetime.DisposeAsync()
    {
        await DisposeAsync();
    }
    
}