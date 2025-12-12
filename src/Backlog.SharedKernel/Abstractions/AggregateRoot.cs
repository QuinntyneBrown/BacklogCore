using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;
using static Newtonsoft.Json.JsonConvert;

namespace Backlog.SharedKernel;

public abstract class AggregateRoot : IAggregateRoot
{
    internal List<StoredEvent> _storedEvents = new List<StoredEvent>();

    [NotMapped]
    public IReadOnlyList<StoredEvent> StoredEvents => _storedEvents.AsReadOnly();

    public AggregateRoot(IEnumerable<IEvent> events)
    {
        foreach (var @event in events) { When(@event); }
    }

    protected AggregateRoot()
    {

    }

    public void StoreEvent(IEvent @event)
    {
        DefaultContractResolver contractResolver = new DefaultContractResolver
        {
            NamingStrategy = new CamelCaseNamingStrategy()
        };

        var type = GetType();

        var eventType = @event.GetType();

        var resolvedEventType = eventType.Name == "Request" ? eventType.BaseType : eventType;

        @event.Items.Add(nameof(Type), resolvedEventType.Name);

        var storedEvent = new StoredEvent
        {
            StoredEventId = Guid.NewGuid(),
            Aggregate = GetType().Name,
            AggregateDotNetType = GetType().AssemblyQualifiedName,
            Data = SerializeObject(@event, new JsonSerializerSettings
            {
                ContractResolver = contractResolver
            }),
            StreamId = (Guid)type.GetProperty($"{type.Name}Id").GetValue(this, null),
            DotNetType = resolvedEventType.AssemblyQualifiedName,
            Type = resolvedEventType.Name,
            CreatedOn = @event.Created,
            CorrelationId = new Guid()
        };

        _storedEvents.Add(storedEvent);
    }

    public AggregateRoot Apply(IEvent @event)
    {
        When(@event);
        EnsureValidState();
        StoreEvent(@event);
        return this;
    }
    protected abstract void When(dynamic @event);
    protected abstract void EnsureValidState();
}