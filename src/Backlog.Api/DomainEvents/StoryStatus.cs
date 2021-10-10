using Backlog.Api.Core;
using System;

namespace Backlog.Api.DomainEvents
{
    public class CreateStoryStatus: BaseDomainEvent {
        public Guid StoryStatusId { get; private set; } = Guid.NewGuid();
        public string Name { get; private set; }

        public CreateStoryStatus(string name)
        {
            Name = name;
        }
    }
}
