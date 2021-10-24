using Backlog.Api.Models;
using System.Linq;

namespace Backlog.Api.Features
{
    public static class StoryExtensions
    {
        public static StoryDto ToDto(this Story story)
        {
            return new(
                story.StoryId,
                story.Name,
                story.Title,
                story.Description,
                story.AcceptanceCriteria)
            {
                JiraUrl = story.JiraUrl,
                SkillRequirements = story?.SkillRequirements.Select(x => new SkillRequirementDto {                 
                    CompetencyLevel = x.CompetencyLevel,
                    Technology = x.Technology
                }).ToList(),
                DependsOn = story?.DependsOn.Select(x => x.DependsOn).ToList()
            };
        }
    }
}
