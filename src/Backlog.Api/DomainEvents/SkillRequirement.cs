using Backlog.Api.Core;
using System;

namespace Backlog.Api.DomainEvents
{
    public class CreateSkillRequirement : BaseDomainEvent
    {
        public Guid SkillRequirementId { get; private set; } = Guid.NewGuid();
        public string Technology { get; private set; }
        public string CompentencyLevel { get; private set; }

        public CreateSkillRequirement(string technology, string compentencyLevel)
        {
            Technology = technology;
            CompentencyLevel = compentencyLevel;
        }
    }

    public class UpdateSkillRequirementTechnology : BaseDomainEvent
    {
        public string Technology { get; private set; }

        public UpdateSkillRequirementTechnology(string technology)
        {
            Technology = technology;
        }
    }

    public class UpdateSkillRequirementCompentencyLevel : BaseDomainEvent
    {
        public string CompentencyLevel { get; private set; }

        public UpdateSkillRequirementCompentencyLevel(string compentencyLevel)
        {
            CompentencyLevel = compentencyLevel;
        }
    }

    public class RemoveSkillRequirement : BaseDomainEvent
    {

    }
}
