using Backlog.Api.Core;
using System;

namespace Backlog.Api.DomainEvents
{
    public class CreateBug : BaseDomainEvent
    {
        public Guid BugId { get; private set; } = Guid.NewGuid();
        public CreateBug()
        {

        }
    }
}
