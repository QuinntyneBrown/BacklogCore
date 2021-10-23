using Backlog.Api.Core;
using System;

namespace Backlog.Api.DomainEvents
{
    public class CreateStatus : BaseDomainEvent
    {
        public Guid StatusId { get; private set; } = Guid.NewGuid();
        public string Name { get; private set; }
        public string Description { get; private set; }

        public CreateStatus(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }

    public class UpdateStatusName : BaseDomainEvent
    {
        public string Name { get; private set; }

        public UpdateStatusName(string name)
        {
            Name = name;
        }
    }

    public class UpdateStatusDescription : BaseDomainEvent
    {
        public string Description { get; private set; }

        public UpdateStatusDescription(string description)
        {
            Description = description;
        }
    }

    public class RemoveStatus : BaseDomainEvent
    {

    }
}
