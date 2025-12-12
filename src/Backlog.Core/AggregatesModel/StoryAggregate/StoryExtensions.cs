using Backlog.SharedKernel;
using System.Linq;

namespace Backlog.Core;

public static class StoryExtensions
{
    public static StoryDto ToDto(this Story story)
    {
        return new(
            story.StoryId,
            story.Name,
            story.Title,
            story.Description,
            story.AcceptanceCriteria,
            story.Status,
            story.Effort)
        {
            JiraUrl = story.JiraUrl,
            SkillRequirements = story?.SkillRequirements.Select(x => new SkillRequirementDto
            {
                CompetencyLevel = x.CompetencyLevel,
                Technology = x.Technology
            }).ToList(),
            DependsOn = story?.DependsOn.Select(x => x.DependsOn).ToList()
        };
    }
}