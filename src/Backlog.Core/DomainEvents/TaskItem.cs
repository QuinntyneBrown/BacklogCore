using Backlog.Api.Core;
using System;

namespace Backlog.Api.DomainEvents
{
    public class CreateTaskItem : BaseDomainEvent
    {
        public Guid TaskItemId { get; set; } = Guid.NewGuid();
    }
}
