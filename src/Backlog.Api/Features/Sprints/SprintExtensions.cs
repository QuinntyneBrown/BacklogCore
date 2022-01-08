using Backlog.Api.Models;
using System.Linq;

namespace Backlog.Api.Features
{
    public static class SprintExtensions
    {
        public static SprintDto ToDto(this Sprint sprint)
        {
            return new ()
            {
                SprintId = sprint?.SprintId,
                Name = sprint?.Name,
                Start = sprint?.Start ?? default,
                End = sprint?.End ?? default,
                StoryIds = sprint?.SprintStories?.Select(x => $"{x.StoryId}").ToList()
            };
        }
        
    }
}
