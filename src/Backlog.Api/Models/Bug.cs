using Backlog.Api.Core;
using Backlog.Api.DomainEvents;
using System;

namespace Backlog.Api.Models
{
    public class Bug : AggregateRoot
    {
        public Guid BugId { get; private set; }
        public Bug(CreateBug @event)
        {
            Apply(@event);
        }

        protected override void EnsureValidState()
        {

        }

        protected override void When(dynamic @event) => When(@event);

        private void When(CreateBug @event)
        {
            BugId = @event.BugId;
        }
    }
}
