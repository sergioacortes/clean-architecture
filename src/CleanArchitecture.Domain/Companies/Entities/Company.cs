using CleanArchitecture.Orders.Domain.Base;

namespace CleanArchitecture.Orders.Domain.Companies.Entities;

public class Company : DomainEntity<Guid>
{

    private Company(string tenantId, string tradeName, Guid databaseId)
        : base(Guid.NewGuid())
    {

        if (string.IsNullOrWhiteSpace(tenantId))
        {
            throw new ArgumentNullException(nameof(tenantId), 
                $"Parameter {nameof(tenantId)} cannot be null or empty");
        }
        
        if (string.IsNullOrWhiteSpace(tradeName))
        {
            throw new ArgumentNullException(nameof(tradeName),
                $"Parameter {nameof(tradeName)} cannot be null or empty");
        }

        if (databaseId == Guid.Empty)
        {
            throw new ArgumentNullException(nameof(databaseId),
                $"Parameter {nameof(databaseId)} cannot be null or empty");
        }
        
        TenantId = tenantId;
        TradeName = tradeName;
        DatabaseId = databaseId;
    }

    public string TenantId { get; private set; }
    
    public string TradeName { get; private set; }

    public Guid DatabaseId { get; private set; }

    public static Company Create(string tenantId, string tradeName, Guid databaseId)
    {
        return new Company(tenantId, tradeName, databaseId);
    }
    
}