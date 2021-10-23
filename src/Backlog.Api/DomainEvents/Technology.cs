using Backlog.Api.Core;
using System;

namespace Backlog.Api.DomainEvents
{
    public class CreateTechnology : BaseDomainEvent
    {
        public Guid TechnologyId { get; private set; } = Guid.NewGuid();
        public string Name { get; private set; }
        public string Description { get; private set; }

        public CreateTechnology(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }

    public class UpdateTechnologyName : BaseDomainEvent
    {
        public string Name { get; private set; }

        public UpdateTechnologyName(string name)
        {
            Name = name;
        }
    }

    public class UpdateTechnologyDescription : BaseDomainEvent
    {
        public string Description { get; private set; }

        public UpdateTechnologyDescription(string description)
        {
            Description = description;
        }
    }

    public class RemoveTechnology : BaseDomainEvent
    {

    }
}
