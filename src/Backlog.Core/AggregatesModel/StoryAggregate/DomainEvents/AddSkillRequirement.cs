using Backlog.Api.Core;
using Backlog.Api.Models;

namespace Backlog.Api.DomainEvents
{
    public class AddSkillRequirement : BaseDomainEvent
    {
        public SkillRequirement SkillRequirement { get; set; }

        public AddSkillRequirement(SkillRequirement skillRequirement)
        {
            SkillRequirement = skillRequirement;
        }
    }
}
