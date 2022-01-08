using Backlog.Api.Core;
using System;

namespace Backlog.Api.DomainEvents
{
    public class CreateSprint: BaseDomainEvent
    {
        public Guid SprintId { get; set; } = Guid.NewGuid();
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public CreateSprint(DateTime start, DateTime end)
        {
            Start = start;
            End = end;  
        }        
    }

    public class AddSprintStory: BaseDomainEvent
    {
        public Guid StoryId { get; private set; }

        public AddSprintStory(Guid storyId)
        {
            StoryId = storyId;
        }
    }
}
