using System.Net.Http.Json;
using CleanArchitecture.Orders.Application.UseCases.Databases.RegisterDatabase;
using CleanArchitecture.Orders.Domain.Databases.Entities;
using CleanArchitecture.Orders.Domain.Databases.Repositories;
using CleanArchitecture.Orders.Infrastructure.SqlServer.DbContexts;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace CleanArchitecture.Api.Host.Integration.Tests.UseCases.Databases;

[Collection(nameof(WebApplicationFixture))]
public class RegisterDatabaseHandlerTests(WebApplicationFixture fixture) : IClassFixture<WebApplicationFixture>
{
    
    [Fact]
    public async Task RegisterDatabaseHandler_Should_RegisterDatabase_And_Disable_Existing_Provisioned_Database()
    {
        
        var cancellationToken = new CancellationTokenSource().Token;
        var currentDatabase = Database.Create("(local)", "CurrentDb", "admin", "password");

        await fixture.SystemDbContext.Databases.AddAsync(currentDatabase, cancellationToken);
        await fixture.SystemDbContext.SaveChangesAsync(cancellationToken);
        
        var httpClient = fixture.CreateClient();
        var registerDatabaseRequest = new RegisterDatabaseRequest("(local)", "CompaniesDb", "admin", "password");
        var httpRequest = await httpClient.PostAsJsonAsync("api/databases", registerDatabaseRequest);

        httpRequest.IsSuccessStatusCode.Should().BeTrue();
        
        var registeredDatabase = await httpRequest.Content.ReadFromJsonAsync<RegisterDatabaseResponse>();

        registeredDatabase.Should().NotBeNull();
        registeredDatabase.Id.Should().NotBeEmpty();
        registeredDatabase.ServerName.Should().NotBeEmpty();
        registeredDatabase.ServerName.Should().Be(registerDatabaseRequest.ServerName);
        registeredDatabase.DatabaseName.Should().NotBeEmpty();
        registeredDatabase.DatabaseName.Should().Be(registerDatabaseRequest.DatabaseName);
        registeredDatabase.UserName.Should().NotBeEmpty();
        registeredDatabase.UserName.Should().Be(registerDatabaseRequest.UserName);
        registeredDatabase.Password.Should().NotBeEmpty();
        registeredDatabase.Password.Should().Be(registerDatabaseRequest.Password);
        
        var databases = await fixture.SystemDbContext.Databases.Where(r => r.IsActive).ToListAsync(cancellationToken);

        databases.Should().NotBeNull();
        databases.Count.Should().Be(1);
        
    }

}