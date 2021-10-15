using MediatR;
using System;
using System.Collections.Generic;

namespace Backlog.Api.Interfaces
{
    public interface IEvent : INotification
    {
        DateTime Created { get; }
        Guid CorrelationId { get; }
        void WithCorrelationIdFrom(IEvent @event);
        Dictionary<string, object> Items { get; }
    }
}
