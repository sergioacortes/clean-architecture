using System.Net.Http.Json;
using CleanArchitecture.Orders.Application.UseCases.Companies;
using CleanArchitecture.Orders.Domain.Databases.Entities;
using FluentAssertions;
using Xunit;

namespace CleanArchitecture.Api.Host.Integration.Tests.UseCases.Companies;

[Collection(nameof(WebApplicationFixture))]
public class CreateCompanyHandlerTests(WebApplicationFixture fixture) : IClassFixture<WebApplicationFixture>
{

    [Fact(DisplayName = "Company should not be created if there is not database active")]
    public async Task CreateCompanyHandler_ShouldNotCreateCompany_If_theres_not_active_database()
    {

        await fixture.ResetDatabase();
        
        var httpClient = fixture.CreateClient();
        var createCompanyRequest = new CreateCompanyRequest("KO001", "Test Company");
        var httpRequest = await httpClient.PostAsJsonAsync("api/companies", createCompanyRequest);

        httpRequest.IsSuccessStatusCode.Should().BeFalse();
    
    }

    [Fact(DisplayName = "Company should be created with active database")]
    public async Task CreateCompanyHandler_ShouldCreateCompany_With_active_Database()
    {
        
        await fixture.ResetDatabase();
        
        var cancellationToken = new CancellationTokenSource().Token;
        
        await fixture.SystemDbContext
            .AddAsync(Database.Create("(local)", "Database", "admin", "password"), cancellationToken)
            .ConfigureAwait(false);
        await fixture.SystemDbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        
        var httpClient = fixture.CreateClient();
        var createCompanyRequest = new CreateCompanyRequest("OK001", "Test Company");
        var httpRequest = await httpClient.PostAsJsonAsync("api/companies", createCompanyRequest);

        httpRequest.IsSuccessStatusCode.Should().BeTrue();
        
        var createCompanyResponse = await httpRequest.Content.ReadFromJsonAsync<CreateCompanyResponse>();

        createCompanyResponse.Should().NotBeNull();
        createCompanyResponse.Id.Should().NotBeEmpty();
        createCompanyResponse.TenantId.Should().NotBeEmpty();
        createCompanyResponse.TenantId.Should().Be(createCompanyRequest.TenantId);
        createCompanyResponse.TradeName.Should().NotBeEmpty();
        createCompanyResponse.TradeName.Should().Be(createCompanyRequest.TradeName);
        
        var company = await fixture.SystemDbContext.Companies.FindAsync(createCompanyResponse.Id, cancellationToken).ConfigureAwait(false);
        
        company.Should().NotBeNull();
        company!.DatabaseId.Should().NotBeEmpty();
        
    }
    
}