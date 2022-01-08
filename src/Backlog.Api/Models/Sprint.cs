using Backlog.Api.Core;
using Backlog.Api.DomainEvents;
using System;
using System.Collections.Generic;

namespace Backlog.Api.Models
{
    public class Sprint: AggregateRoot
    {
        public Guid SprintId { get; private set; }
        public string Name { get; set; }
        public DateTime Start { get; private set; }
        public DateTime End { get; private set; }
        public List<SprintStory> SprintStories { get; private set; }

        public Sprint(CreateSprint @event)
        {
            Apply(@event);
        }

        private Sprint()
        {

        }

        protected override void EnsureValidState()
        {

        }

        protected override void When(dynamic @event) => When(@event);

        private void When(CreateSprint @event)
        {
            SprintId = @event.SprintId;
            Name = @event.Name;
            Start = @event.Start;
            End = @event.End;   
            SprintStories = new List<SprintStory>();
        }

        private void When(AddSprintStory @event)
        {
            SprintStories.Add(new SprintStory { StoryId = @event.StoryId });
        }
    }
}
