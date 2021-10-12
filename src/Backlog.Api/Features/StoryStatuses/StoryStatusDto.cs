using System;

namespace Backlog.Api.Features
{
    public class StoryStatusDto
    {
        public Guid? StoryStatusId { get; private set; }
        public string Name { get; private set; }

        public StoryStatusDto(string name)
        {
            Name = name;
        }

        public StoryStatusDto(Guid storyStatusId, string name)
            : this(name)
        {
            StoryStatusId = storyStatusId;
        }
    }
}
