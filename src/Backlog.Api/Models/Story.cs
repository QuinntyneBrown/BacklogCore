using Backlog.Api.Core;
using Backlog.Api.DomainEvents;
using System;

namespace Backlog.Api.Models
{
    public class Story : AggregateRoot
    {
        public Guid StoryId { get; private set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; private set; }
        public string AcceptanceCriteria { get; private set; }

        public Story(CreateStory @event)
        {
            Apply(@event);
        }
        protected override void EnsureValidState()
        {

        }

        protected override void When(dynamic @event) => When(@event);

        private void When(CreateStory @event)
        {
            StoryId = @event.StoryId;
            Title = @event.Title;
            Name = @event.Name;
            Description = @event.Description;
            AcceptanceCriteria = @event.AcceptanceCriteria;
        }
    }
}
