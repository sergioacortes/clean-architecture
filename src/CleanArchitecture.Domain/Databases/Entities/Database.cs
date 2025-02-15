using CleanArchitecture.Orders.Domain.Base;

namespace CleanArchitecture.Orders.Domain.Databases.Entities;

public class Database : DomainEntity<Guid>
{
    private Database(Guid id, string serverName, string databaseName, string userName, string password) : base(id)
    {
        ServerName = serverName ?? throw new ArgumentNullException(nameof(serverName));
        DatabaseName = databaseName ?? throw new ArgumentNullException(nameof(databaseName));
        UserName = userName ?? throw new ArgumentNullException(nameof(userName));
        Password = password ?? throw new ArgumentNullException(nameof(password));
        IsActive = true;
    }
    
    public string ServerName { get; private set; }

    public string DatabaseName { get; private set; }
    
    public string UserName { get; private set; }

    public string Password { get; private set; }

    public bool IsActive { get; private set; }
    
    public static Database Create(string serverName, string databaseName, string userName, string password)
    {
        
        var database = new Database(Guid.NewGuid(), serverName, databaseName, userName, password);
        return database;
        
    }

}