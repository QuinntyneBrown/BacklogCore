using Backlog.Api.Core;
using Backlog.Api.DomainEvents;
using System;

namespace Backlog.Api.Models
{
    public class DependencyRelationship: AggregateRoot
    {
        public Guid DependencyRelationshipId { get; private set; }
        public string Target { get; private set; }
        public string DependsOn { get; private set; }

        private DependencyRelationship()
        {

        }

        public DependencyRelationship(CreateDependencyRelationship @event)
        {
            Apply(@event);
        }

        protected override void EnsureValidState()
        {

        }

        protected override void When(dynamic @event) => When(@event);

        private void When(CreateDependencyRelationship @event)
        {
            DependencyRelationshipId = @event.DependencyRelationshipId;
            Target = @event.Target;
            DependsOn = @event.DependsOn;
        }

        private void When(UpdateDependencyRelationshipTargetId @event)
        {
            Target = @event.Target;
        }
        private void When(UpdateDependencyRelationshipDependsOnId @event)
        {
            DependsOn = @event.DependsOn;
        }

        private void When(RemoveDependencyRelationship @event)
        {

        }
    }
}
