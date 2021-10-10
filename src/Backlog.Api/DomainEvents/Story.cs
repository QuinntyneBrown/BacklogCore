using Backlog.Api.Core;
using System;

namespace Backlog.Api.DomainEvents
{
    public class CreateStory : BaseDomainEvent
    {
        public Guid StoryId { get; private set; } = Guid.NewGuid();
        public string Name { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string AcceptanceCriteria { get; private set; }

        public CreateStory(
            string name,
            string title,
            string description,
            string acceptanceCriteria)
        {
            Name = name;
            Title = title;
            Description = description;
            AcceptanceCriteria = acceptanceCriteria;
        }
    }
}
