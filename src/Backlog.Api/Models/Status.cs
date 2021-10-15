using Backlog.Api.Core;
using Backlog.Api.DomainEvents;
using System;

namespace Backlog.Api.Models
{
    public class Status: AggregateRoot
    {
        public Guid StatusId { get; private set; }
        public string Name { get; private set; }

        private Status()
        {

        }

        public Status(CreateStatus @event)
        {
            Apply(@event);
        }

        protected override void When(dynamic @event) => When(@event);

        protected override void EnsureValidState()
        {

        }
    }
}
