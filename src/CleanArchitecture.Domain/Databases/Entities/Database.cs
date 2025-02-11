using CleanArchitecture.Orders.Domain.Base;

namespace CleanArchitecture.Orders.Domain.Databases.Entities;

public class Database : DomainEntity<Guid>
{
    private Database(Guid id, string databaseName) : base(id)
    {
        DatabaseName = databaseName;
        IsActive = true;
    }

    public string DatabaseName { get; private set; }
    
    public bool IsActive { get; private set; }
    
    public static Database Create(string databaseName)
    {
        
        var database = new Database(Guid.NewGuid(), databaseName);
        return database;
        
    }

}