using Backlog.Api.Models;

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
                story.AcceptanceCriteria);
        }
    }
}
