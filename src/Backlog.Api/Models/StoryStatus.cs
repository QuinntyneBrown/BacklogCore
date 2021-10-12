using Backlog.Api.Core;
using Backlog.Api.DomainEvents;
using System;

namespace Backlog.Api.Models
{
    public class StoryStatus : AggregateRoot
    {
        public Guid StoryStatusId { get; set; }
        public string Name { get; set; }

        public StoryStatus(CreateStoryStatus @event)
        {
            Apply(@event);
        }

        protected override void EnsureValidState()
        {

        }

        protected override void When(dynamic @event) => When(@event);

        private void When(CreateStoryStatus @event)
        {
            StoryStatusId = @event.StoryStatusId;
            Name = @event.Name;
        }
    }
}
