using Backlog.Api.Core;
using Backlog.Api.DomainEvents;
using System;

namespace Backlog.Api.Models
{
    public class Status: AggregateRoot
    {
        public Guid StatusId { get; private set; }
        public string Name { get; private set; }
        public string Description { get; set; }

        private Status()
        {

        }

        public Status(CreateStatus @event)
        {
            Apply(@event);
        }

        protected override void When(dynamic @event) => When(@event);
        private void When(CreateStatus @event)
        {
            StatusId = @event.StatusId;
            Name = @event.Name;
            Description = @event.Description;
        }

        private void When(UpdateStatusName @event)
        {
            Name = @event.Name;
        }

        private void When(UpdateStatusDescription @event)
        {
            Description = @event.Description;
        }

        private void When(RemoveStatus @event)
        {

        }

        protected override void EnsureValidState()
        {

        }
    }
}
