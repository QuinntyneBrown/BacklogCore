using Backlog.Api.Core;
using Backlog.Api.DomainEvents;
using System;

namespace Backlog.Api.Models
{
    public class DependencyRelationship: AggregateRoot
    {
        public Guid DependencyRelationshipId { get; private set; }
        public Guid TargetId { get; private set; }
        public Guid DependsOnId { get; private set; }

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
            TargetId = @event.TargetId;
            DependsOnId = @event.DependsOnId;
        }

        private void When(UpdateDependencyRelationshipTargetId @event)
        {
            TargetId = @event.TargetId;
        }
        private void When(UpdateDependencyRelationshipDependsOnId @event)
        {
            DependsOnId = @event.DependsOnId;
        }

        private void When(RemoveDependencyRelationship @event)
        {

        }
    }
}
