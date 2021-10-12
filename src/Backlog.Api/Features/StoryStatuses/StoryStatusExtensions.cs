using Backlog.Api.Models;

namespace Backlog.Api.Features
{
    public static class StoryStatusExtensions
    {
        public static StoryStatusDto ToDto(this StoryStatus storyStatus)
        {
            return new(storyStatus.StoryStatusId, storyStatus.Name);
        }

    }
}
