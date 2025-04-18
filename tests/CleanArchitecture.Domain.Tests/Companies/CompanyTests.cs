using CleanArchitecture.Domain.Companies;
using CleanArchitecture.Domain.Companies.Events;
using FluentAssertions;
using Xunit;

namespace CleanArchitecture.Domain.Tests.Companies;

[Trait("CleanArchitecture.Domain", "CleanArchitecture")]
public class CompanyTests
{

    [Fact(DisplayName = "Company name should be valid")]
    public void Create_company_should_be_valid()
    {

        var tradeName = "Company trade name";
        var company = Company.Create(tradeName);

        company.Should().NotBeNull();
        company.TradeName.Should().Be(tradeName);
        company.Sequence.Should().Be(company.CreatedAt.Ticks);
        
        var events = company.GetDomainEvents();
            
        events.Count().Should().Be(1);
        events.First().Should().BeOfType<CompanyCreatedDomainEvent>();
        
        var @event = events.First() as CompanyCreatedDomainEvent;
        @event!.Id.Should().NotBeEmpty();
        @event.AggregateId.Should().Be(company.Id);
        @event.TradeName.Should().Be(company.TradeName);
        @event.CreatedAt.Should().BeAfter(company.CreatedAt);
    }
    
    [Theory(DisplayName = "Company name should be invalid")]
    [InlineData(null)]
    [InlineData("")]
    public void Create_company_should_be_invalid(string tradeName)
    {
        Assert.Throws<ArgumentNullException>(() => Company.Create(tradeName));
    }

}