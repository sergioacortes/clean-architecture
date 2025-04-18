namespace CleanArchitecture.Domain.Base;

public abstract class DomainEntity<TType> 
{

    protected DomainEntity(TType id)
    {
        Id = id;
        CreatedAt = DateTime.UtcNow;
        Sequence = CreatedAt.Ticks;
    }

    private List<DomainEvent> DomainEvents { get; } = [];
    
    public TType Id { get; private set; }
    
    public DateTime CreatedAt { get; private set; }
    
    public long Sequence { get; private set; }

    internal void AddDomainEvent(DomainEvent domainEvent) => 
        DomainEvents.Add(domainEvent);
    
    public List<DomainEvent> GetDomainEvents() => 
        DomainEvents;
    
}