using CleanArchitecture.Domain.Base;
using CleanArchitecture.Domain.Companies.Events;

namespace CleanArchitecture.Domain.Companies;

public partial class Company : DomainEntity<Guid>
{

    private Company(string tradeName)
        : base(Guid.NewGuid())
    {
        TradeName = tradeName;
        this.AddDomainEvent(new CompanyCreatedDomainEvent(Id, TradeName));
    }

    public string TradeName { get; set; }
    
}