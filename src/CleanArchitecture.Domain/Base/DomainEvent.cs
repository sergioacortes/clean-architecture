namespace CleanArchitecture.Domain.Base;

public abstract class DomainEvent(Guid id, Guid aggregateId)
{
    public Guid Id { get; } = id;
    public Guid AggregateId { get; } = aggregateId;
    public DateTime CreatedAt { get; } = DateTime.UtcNow;
}