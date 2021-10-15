using Backlog.Api.Core;
using System;

namespace Backlog.Api.DomainEvents
{
    public class CreateStatus : BaseDomainEvent {
        public Guid StatusId { get; private set; } = Guid.NewGuid();
        public string Name { get; private set; }
        public CreateStatus(string name)
        {
            Name = name;
        }
    }
}
