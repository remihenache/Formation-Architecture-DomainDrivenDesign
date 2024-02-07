namespace DDD.Samples.TravelAgency.Core;

public interface DomainEventListener<T> where T : DomainEvent
{
    Task Handle(T domainEvent);
}