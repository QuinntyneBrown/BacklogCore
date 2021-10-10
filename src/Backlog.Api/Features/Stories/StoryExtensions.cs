using System;
using Backlog.Api.Models;

namespace Backlog.Api.Features
{
    public static class StoryExtensions
    {
        public static StoryDto ToDto(this Story story)
        {
            return new ()
            {
                StoryId = story.StoryId
            };
        }
        
    }
}
