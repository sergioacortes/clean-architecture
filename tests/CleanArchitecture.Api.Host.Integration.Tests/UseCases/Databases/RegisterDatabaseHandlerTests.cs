using Xunit;

namespace CleanArchitecture.Api.Host.Integration.Tests.UseCases.Databases;

[Collection(nameof(WebApplicationFixture))]
public class RegisterDatabaseHandlerTests(WebApplicationFixture fixture) : IClassFixture<WebApplicationFixture>
{
    
    [Fact]
    public async Task RegisterDatabaseHandler_Should_RegisterDatabase_And_Disable_Existing_Provisioned_Database()
    {
        
        await fixture.ExecuteTestOnIsolatedContext(async () =>
        {
            var httpClient = fixture.CreateClient();
            var registerDatabaseRequest = new RegisterDatabaseRequest("(local)", "CompaniesDb", "admin", "password");
            var httpRequest = await httpClient.PostAsJsonAsync("api/companies", createCompanyRequest);

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
            
        });
        
    }

}