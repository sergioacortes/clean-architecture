using CleanArchitecture.Orders.Domain.Companies.Entities;
using FluentAssertions;
using Xunit;

namespace CleanArchitecture.Domain.Tests.Companies.Entities;

public class CompanyTests
{
    [Fact]
    public void Null_Company_Name_Should_Not_Be_Able_To_Create_Company()
    {

        var companyName = string.Empty;

        Assert.Throws<ArgumentNullException>(() => Company.Create(string.Empty));
    }
    
    [Fact]
    public void Company_Name_Should_Be_Able_To_Create_Company()
    {

        var companyName = "Company trade name";
        var company = Company.Create(companyName);
        
        company.TradeName.Should().Be(companyName);
    }
}