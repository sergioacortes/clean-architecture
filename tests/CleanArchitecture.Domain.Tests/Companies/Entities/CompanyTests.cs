using CleanArchitecture.Orders.Domain.Companies.Entities;
using FluentAssertions;
using Xunit;

namespace CleanArchitecture.Domain.Tests.Companies.Entities;

public class CompanyTests
{

    [Theory]
    [InlineData("", "", "d9ccbda3-60bd-4a22-8626-000000000001"),
     InlineData(null, "", "d9ccbda3-60bd-4a22-8626-000000000001"),
     InlineData("", null, "d9ccbda3-60bd-4a22-8626-000000000001"),
     InlineData(null, null, "d9ccbda3-60bd-4a22-8626-000000000001"),
     InlineData("TenantId", "Company name", "00000000-0000-0000-0000-000000000000")
    ]
    public void Company_Should_Not_Be_Able_To_Created(string tenantId, string companyName, Guid databaseId)
    {
        Assert.Throws<ArgumentNullException>(() => Company.Create(tenantId, companyName, databaseId));
    }
    
    [Fact]
    public void Company_Name_Should_Be_Able_To_Create_Company()
    {

        var tenantId = "TenantId";
        var companyName = "Company trade name";
        var databaseId = Guid.NewGuid();
        var company = Company.Create(tenantId, companyName, databaseId);
        
        company.Id.Should().NotBeEmpty();
        company.TradeName.Should().Be(companyName);
        company.DatabaseId.Should().NotBeEmpty();

    }
}