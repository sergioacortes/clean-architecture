using CleanArchitecture.Orders.Domain.Base;

namespace CleanArchitecture.Orders.Domain.Companies.Entities;

public class Company : DomainEntity<Guid>
{

    private Company(string tenantId, string tradeName)
        : base(Guid.NewGuid())
    {
        TenantId = tenantId;
        TradeName = tradeName;
    }

    public string TenantId { get; private set; }
    
    public string TradeName { get; private set; }
    
    public static Company Create(string tenantId, string tradeName)
    {
        
        if (string.IsNullOrEmpty(tenantId))
        {
            throw new ArgumentNullException(nameof(tenantId), $"Parameter {nameof(tenantId)} cannot be null or empty");
        }
        
        if (string.IsNullOrEmpty(tradeName))
        {
            throw new ArgumentNullException(nameof(tradeName), $"Parameter {nameof(tradeName)} cannot be null or empty");
        }
        
        return new Company(tenantId, tradeName);
    }
    
}