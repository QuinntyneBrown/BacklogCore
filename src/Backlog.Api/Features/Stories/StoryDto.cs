using System;

namespace Backlog.Api.Features
{
    public class StoryDto
    {
        public Guid? StoryId { get; private set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; private set; }
        public string AcceptanceCriteria { get; private set; }

        public StoryDto(string name, string title, string description, string acceptanceCriteria)
        {
            Name = name;
            Title = title;
            Description = description;
            AcceptanceCriteria = acceptanceCriteria;
        }

        public StoryDto(Guid storyId, string name, string title, string description, string acceptanceCriteria)
            : this(name, title, description, acceptanceCriteria)
        {
            StoryId = storyId;
        }
    }
}
