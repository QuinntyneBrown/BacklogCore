using Backlog.Api.Core;
using System;

namespace Backlog.Api.DomainEvents
{
    public class CreateCompetencyLevel: BaseDomainEvent {
        public Guid CompetencyLevelId { get; private set; } = Guid.NewGuid();
        public string Name { get; private set; }
        public string Description { get; private set; }

        public CreateCompetencyLevel(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }

    public class UpdateCompetencyLevelName : BaseDomainEvent
    {
        public string Name { get; private set; }

        public UpdateCompetencyLevelName(string name)
        {
            Name = name;
        }
    }

    public class UpdateCompetencyLevelDescription : BaseDomainEvent
    {
        public string Description { get; private set; }

        public UpdateCompetencyLevelDescription(string description)
        {
            Description = description;
        }
    }

    public class RemoveCompetencyLevel : BaseDomainEvent
    {

    }
}
