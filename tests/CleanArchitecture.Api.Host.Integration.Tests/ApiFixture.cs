using CleanArchitecture.Api.Host.Integration.Tests.Containers;
using CleanArchitecture.Orders.Infrastructure.SqlServer.DbContexts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace CleanArchitecture.Api.Host.Integration.Tests;

public class ApiFixture : WebApplicationFactory<Program>, IAsyncLifetime
{

    private readonly SqlServerContainer _sqlServerContainer = new();
    
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureAppConfiguration(_ => { });
        builder.ConfigureServices(_ => { });;
        
        builder.UseSetting("ConnectionStrings:SystemConnection", _sqlServerContainer.Container.GetConnectionString());
        
        base.ConfigureWebHost(builder);
    }

    public async Task InitializeAsync()
    {
        await _sqlServerContainer.Container.StartAsync();
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
    
    public async Task ExecuteTestOnIsolatedContext(Func<Task> testAction)
    {
        //We can't use the TestDbContext for migrations
        using var serviceScope = Services.CreateScope();
        await using var migrationDbContext = serviceScope.ServiceProvider.GetRequiredService<SystemDbContext>();
        await migrationDbContext.Database.EnsureCreatedAsync();

        await testAction();
    }
    
}