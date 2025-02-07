namespace CleanArchitecture.Orders.Domain.Base;

public abstract record DomainEvent (Guid Id, DateTime Version, long SequenceVersion);