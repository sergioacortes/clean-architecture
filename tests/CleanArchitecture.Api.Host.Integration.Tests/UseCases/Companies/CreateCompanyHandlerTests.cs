using System.Net.Http.Json;
using CleanArchitecture.Api.Host.Integration.Tests.Containers;
using CleanArchitecture.Orders.Application.UseCases.Companies;
using FluentAssertions;
using Xunit;

namespace CleanArchitecture.Api.Host.Integration.Tests.UseCases.Companies;

[Collection(nameof(WebApplicationFixture))]
public class CreateCompanyHandlerTests(WebApplicationFixture fixture) : IClassFixture<WebApplicationFixture>
{

    [Fact]
    public async Task CreateCompanyHandler_ShouldCreateCompany_With_Default_Database()
    {

        await fixture.ExecuteTestOnIsolatedContext(async (_) =>
        {
            var httpClient = fixture.CreateClient();
            var createCompanyRequest = new CreateCompanyRequest("TenantId", "Test Company");
            var httpRequest = await httpClient.PostAsJsonAsync("api/companies", createCompanyRequest);

            httpRequest.IsSuccessStatusCode.Should().BeTrue();
            
            var company = await httpRequest.Content.ReadFromJsonAsync<CreateCompanyResponse>();

            company.Should().NotBeNull();
            company.Id.Should().NotBeEmpty();
            company.TenantId.Should().NotBeEmpty();
            company.TenantId.Should().Be(createCompanyRequest.TenantId);
            company.TradeName.Should().NotBeEmpty();
            company.TradeName.Should().Be(createCompanyRequest.TradeName);
            company.DatabaseId.Should().NotBeEmpty();

        });
        
    }
    
}