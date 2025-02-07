namespace CleanArchitecture.Orders.Domain.Base;

public abstract class DomainEntity<T>
{
    
    protected readonly List<DomainEvent> _domainEvents = new();

    internal DomainEntity(T id)
    {
        Id = id;
        Version = DateTime.UtcNow;
        SequenceVersion = DateTime.UtcNow.Ticks;
    }

    public T Id { get;  private set; }
    
    public DateTime Version { get; private set; }
    
    public long SequenceVersion { get; private set; }
    
}