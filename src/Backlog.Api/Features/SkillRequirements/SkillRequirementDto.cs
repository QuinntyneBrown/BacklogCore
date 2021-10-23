using System;

namespace Backlog.Api.Features
{
    public class SkillRequirementDto
    {
        public Guid SkillRequirementId { get; set; }
        public string Technology { get; set; }
        public string CompentencyLevel { get; set; }
    }
}
