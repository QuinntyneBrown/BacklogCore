using Backlog.Api.Core;
using System;

namespace Backlog.Api.DomainEvents
{
    public class CreateSkillRequirement: BaseDomainEvent {
        public Guid CreateSkillRequirementId { get; private set; } = Guid.NewGuid();
        public string Name { get; private set; }
        public string Description { get; private set; }
    }
}
