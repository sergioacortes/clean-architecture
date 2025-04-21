using System.Net.Http.Json;
using CleanArchitecture.Application.Companies.CreateCompany;
using FluentAssertions;
using Xunit;

namespace CleanArchitecture.Api.Host.Integration.Tests.Companies;

[Trait("CleanArchitecture.Api.Host", "CreateCompany")]
[Collection(nameof(BaseFixture))]
public class CreateCompanyTests(BaseFixture fixture) : IClassFixture<BaseFixture>, IAsyncLifetime
{
    
    [Fact(DisplayName = "Company should be created with active database")]
    public async Task CreateCompanyHandler_ShouldCreateCompany_With_active_Database()
    {
        var cancellationToken = new CancellationTokenSource().Token;
        
        var httpClient = fixture.CreateClient();
        var createCompanyRequest = new CreateCompanyRequest("Company trade name");
        var httpRequest = await httpClient.PostAsJsonAsync("api/companies", createCompanyRequest, cancellationToken);

        httpRequest.IsSuccessStatusCode.Should().BeTrue();
        
        var createCompanyResponse = await httpRequest.Content.ReadFromJsonAsync<CreateCompanyResponse>(cancellationToken);

        createCompanyResponse.Should().NotBeNull();
        createCompanyResponse.AggregateId.Should().NotBeEmpty();
        createCompanyResponse.TradeName.Should().NotBeEmpty();
        createCompanyResponse.TradeName.Should().Be(createCompanyRequest.TradeName);
    }
    
    public Task InitializeAsync() => Task.CompletedTask;

    public async Task DisposeAsync() => await fixture.ResetDatabase();
}