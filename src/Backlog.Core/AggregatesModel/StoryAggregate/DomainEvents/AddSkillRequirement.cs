using Backlog.SharedKernel;

namespace Backlog.Core;

public class AddSkillRequirement : BaseDomainEvent
{
    public SkillRequirement SkillRequirement { get; set; }

    public AddSkillRequirement(SkillRequirement skillRequirement)
    {
        SkillRequirement = skillRequirement;
    }
}