using CleanArchitecture.Orders.Domain.Base;

namespace CleanArchitecture.Orders.Domain.Companies.Entities;

public class Company : DomainEntity<Guid>
{

    private Company(string tradeName)
        : base(Guid.NewGuid())
    {
        TradeName = tradeName;
    }

    public string TradeName { get; private set; }
    
    public static Company Create(string tradeName)
    {
        
        if (string.IsNullOrWhiteSpace(tradeName))
        {
            throw new ArgumentException("Trade name cannot be null or empty");
        }
        
        return new Company(tradeName);
    }
    
}