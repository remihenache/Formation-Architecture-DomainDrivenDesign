using System.Reflection;

namespace DDD.Samples.TravelAgency.Core;

public class FakeDomainEventDispatcher : DomainEventDispatcher
{
    public async Task Publish<T>(T domainEvent) where T : DomainEvent
    {
        var typeOfDomainEvent = domainEvent.GetType();
        Assembly.GetAssembly(this.GetType())
            .GetTypes().Where(t => IsEventListener(t, typeOfDomainEvent))
            .ToList()
            .ForEach(t =>
            {
                var handler = (DomainEventListener<T>)Activator.CreateInstance(t);
                handler.Handle(domainEvent);
            });
            
    }

    private bool IsEventListener(Type t, Type eventType)
    {
        return t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(DomainEventListener<>) && i.GetGenericArguments().First() == eventType);
    }
}