using CleanArchitecture.Orders.Domain.Companies.Entities;
using FluentAssertions;
using Xunit;

namespace CleanArchitecture.Domain.Tests.Companies.Entities;

public class CompanyTests
{

    [Theory]
    [InlineData("", ""),
     InlineData(null, ""),
     InlineData("", null),
     InlineData(null, null)]
    public void Company_Should_Not_Be_Able_To_Created(string tenantId, string companyName)
    {
        Assert.Throws<ArgumentNullException>(() => Company.Create(tenantId, companyName));
    }
    
    [Fact]
    public void Company_Name_Should_Be_Able_To_Create_Company()
    {

        var tenantId = "TenantId";
        var companyName = "Company trade name";
        var company = Company.Create(tenantId, companyName);
        
        company.Id.Should().NotBeEmpty();
        company.TradeName.Should().Be(companyName);
        company.DatabaseId.Should().NotBeEmpty();

    }
}