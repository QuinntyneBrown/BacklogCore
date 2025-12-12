using Microsoft.EntityFrameworkCore;
using System;

namespace Backlog.Core;
[Owned]
public class SkillRequirement
{
    public string Technology { get; private set; }
    public string CompetencyLevel { get; private set; }

    private SkillRequirement()
    {

    }

    public SkillRequirement(string technology, string competencyLevel)
    {
        Technology = technology;
        CompetencyLevel = competencyLevel;
    }
}
}
