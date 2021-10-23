using Backlog.Api.Core;
using Backlog.Api.DomainEvents;
using System;

namespace Backlog.Api.Models
{
    public class CompentencyLevel: AggregateRoot
    {
        public Guid CompentencyLevelId { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        private CompentencyLevel()
        {

        }

        public CompentencyLevel(CreateCompentencyLevel @event)
        {
            Apply(@event);
        }

        protected override void EnsureValidState()
        {

        }

        protected override void When(dynamic @event) => When(@event);

        private void When(CreateCompentencyLevel @event)
        {
            CompentencyLevelId = @event.CompentencyLevelId;
            Name = @event.Name;
            Description = @event.Description;
        }

        private void When(UpdateCompentencyLevelName @event)
        {
            Name = @event.Name;
        }

        private void When(UpdateCompentencyLevelDescription @event)
        {
            Description = @event.Description;
        }
    }
}
