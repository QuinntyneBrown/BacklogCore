using System;
using Backlog.Api.Models;

namespace Backlog.Api.Features
{
    public static class SkillRequirementExtensions
    {
        public static SkillRequirementDto ToDto(this SkillRequirement skillRequirement)
        {
            return new ()
            {
                SkillRequirementId = skillRequirement.SkillRequirementId,
                Technology = skillRequirement.Technology,
                CompentencyLevel = skillRequirement.CompentencyLevel
            };
        }
        
    }
}
