using CleanArchitecture.Orders.Domain.Databases.Entities;
using FluentAssertions;
using Xunit;

namespace CleanArchitecture.Domain.Tests.Databases.Entities;

public class DatabaseTests
{

    [Fact(DisplayName = "Create a new provisioned database")]
    public void CreateNewProvisionedDatabase()
    {
        var serverName = "(local)";
        var databaseName = "database";
        var userName = "admin";
        var password = "password";
        var database = Database.Create(serverName, databaseName, userName, password);

        database.Should().NotBeNull();
        database.DatabaseName.Should().Be(databaseName);
        database.IsActive.Should().BeTrue();

    }
    
    [Theory(DisplayName = "Create a new provisioned database fail")]
    [InlineData(null, "database", "admin", "password")]
    [InlineData("(local)", null, "admin", "password")]
    [InlineData("(local)", "database", null, "password")]
    [InlineData("(local)", "database", "admin", null)]
    public void CreateNewProvisionedDatabaseFail(string serverName, string databaseName, string userName, string password)
    {
        Assert.Throws<ArgumentNullException>(() => Database.Create(serverName, databaseName, userName, password));
    }
    
}