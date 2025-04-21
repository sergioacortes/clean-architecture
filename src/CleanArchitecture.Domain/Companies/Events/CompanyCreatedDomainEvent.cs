using CleanArchitecture.Domain.Base;

namespace CleanArchitecture.Domain.Companies.Events;

public class CompanyCreatedDomainEvent(Guid companyId, string tradeName) : DomainEvent(Guid.NewGuid(), companyId)
{
    public string TradeName { get; set; } = tradeName;
}