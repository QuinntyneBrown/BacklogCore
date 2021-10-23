using Backlog.Api.Core;
using Backlog.Api.DomainEvents;
using System;

namespace Backlog.Api.Models
{
    public class Technology: AggregateRoot
    {
        public Guid TechnologyId { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public Technology(CreateTechnology @event)
        {
            Apply(@event);
        }

        private Technology()
        {

        }

        protected override void EnsureValidState()
        {

        }

        protected override void When(dynamic @event) => When(@event);

        private void When(CreateTechnology @event)
        {
            TechnologyId = @event.TechnologyId;
            Name = @event.Name;
            Description = @event.Description;
        }

        private void When(UpdateTechnologyName @event)
        {
            Name = @event.Name;
        }

        private void When(UpdateTechnologyDescription @event)
        {
            Description = @event.Description;
        }
    }
}
