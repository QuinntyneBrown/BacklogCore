using System;
using Backlog.Api.Models;

namespace Backlog.Api.Features
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
