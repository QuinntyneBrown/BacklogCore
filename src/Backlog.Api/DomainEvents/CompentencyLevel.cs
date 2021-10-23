using Backlog.Api.Core;
using System;

namespace Backlog.Api.DomainEvents
{
    public class CreateCompentencyLevel: BaseDomainEvent {
        public Guid CompentencyLevelId { get; private set; } = Guid.NewGuid();
        public string Name { get; private set; }
        public string Description { get; private set; }

        public CreateCompentencyLevel(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }

    public class UpdateCompentencyLevelName : BaseDomainEvent
    {
        public string Name { get; private set; }

        public UpdateCompentencyLevelName(string name)
        {
            Name = name;
        }
    }

    public class UpdateCompentencyLevelDescription : BaseDomainEvent
    {
        public string Description { get; private set; }

        public UpdateCompentencyLevelDescription(string description)
        {
            Description = description;
        }
    }

    public class RemoveCompentencyLevel : BaseDomainEvent
    {

    }
}
