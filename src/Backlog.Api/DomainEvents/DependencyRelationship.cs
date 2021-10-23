using Backlog.Api.Core;
using System;

namespace Backlog.Api.DomainEvents
{
    public class CreateDependencyRelationship: BaseDomainEvent {
        public Guid DependencyRelationshipId { get; private set; } = Guid.NewGuid();
        public Guid TargetId { get; private set; }
        public Guid DependsOnId { get; private set; }

        public CreateDependencyRelationship(Guid targetId, Guid dependsOnId)
        {
            TargetId = targetId;
            DependsOnId = dependsOnId;
        }
    }

    public class RemoveDependencyRelationship: BaseDomainEvent
    {

    }
}
