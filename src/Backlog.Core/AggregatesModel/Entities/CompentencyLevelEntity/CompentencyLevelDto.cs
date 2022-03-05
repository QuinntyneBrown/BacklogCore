using System;

namespace Backlog.Api.Features
{
    public class CompetencyLevelDto
    {
        public Guid CompetencyLevelId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
