using Backlog.Api.Interfaces;
using System;
using System.Collections.Generic;

namespace Backlog.Api.Core
{
    public class BaseDomainEvent : IEvent
    {
        public DateTime Created { get; set; } = DateTime.UtcNow;

        public Guid CorrelationId { get; set; }
        public Dictionary<string, object> Items { get; private set; }

        public void WithCorrelationIdFrom(IEvent @event)
        {

        }
    }
}
