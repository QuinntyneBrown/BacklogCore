using System;
using Backlog.Core;

namespace Backlog.Core
{
    public static class CompetencyLevelExtensions
    {
        public static CompetencyLevelDto ToDto(this CompetencyLevel competencyLevel)
        {
            return new()
            {
                CompetencyLevelId = competencyLevel.CompetencyLevelId,
                Description = competencyLevel.Description,
                Name = competencyLevel.Name
            };
        }

    }
}
