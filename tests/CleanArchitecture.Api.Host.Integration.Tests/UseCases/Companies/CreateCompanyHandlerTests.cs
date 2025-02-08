using System.Net.Http.Json;
using CleanArchitecture.Api.Host.Integration.Tests.Containers;
using CleanArchitecture.Orders.Application.UseCases.Companies;
using FluentAssertions;
using Xunit;

namespace CleanArchitecture.Api.Host.Integration.Tests.UseCases.Companies;

[Collection(nameof(SqlServerContainer.FixtureName))]
public class CreateCompanyHandlerTests(ApiFixture fixture) : IClassFixture<ApiFixture>
{

    [Fact]
    public async Task CreateCompanyHandler_ShouldCreateCompany()
    {

        await fixture.ExecuteTestOnIsolatedContext(async () =>
        {
            var httpClient = fixture.CreateClient();
            var createCompanyRequest = new CreateCompanyRequest("Test Company");
            var httpRequest = await httpClient.PostAsJsonAsync("api/companies", createCompanyRequest);

            httpRequest.IsSuccessStatusCode.Should().BeTrue();
            
            var company = await httpRequest.Content.ReadFromJsonAsync<CreateCompanyResponse>();

            company.Should().NotBeNull();
            company.Id.Should().NotBeEmpty();
            company.TradeName.Should().NotBeEmpty();
            company.TradeName.Should().Be(createCompanyRequest.TradeName);

        });
        
    }
    
}