using Xunit;

namespace CleanArchitecture.Domain.Tests.Databases.Entities;

public class DatabaseTests
{

    [Fact(DisplayName = "Create a new provisioned database")]
    public void CreateNewProvisionedDatabase()
    {
        var databaseName = "CompanyDb";
        var database = Database.Create(databaseName);

        database.Should().NotBeNull();
        database.Name.Should().Be(databaseName);
        database.IsActive.Should().BeTrue();

    }
    
}