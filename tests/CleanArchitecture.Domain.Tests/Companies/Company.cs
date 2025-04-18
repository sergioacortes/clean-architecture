using FluentAssertions;
using Xunit;

namespace CleanArchitecture.Domain.Tests.Companies;

[Trait("CleanArchitecture.Domain", "CleanArchitecture")]
public class Company
{

    [Fact(DisplayName = "Company name should be valid")]
    public void Create_company_should_be_valid()
    {

        var tradeName = "Company trade name";
        var company = Company.Create(tradeName);

        company.Should().NotBeNull();
        company.TradeName.Should().Be(tradeName);

    }
    
    [Theory(DisplayName = "Company name should be invalid")]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public void Create_company_should_be_invalid(string tradeName)
    {
        Assert.Throws<ArgumentNullException>(() => Company.Create(tradeName));
    }

}