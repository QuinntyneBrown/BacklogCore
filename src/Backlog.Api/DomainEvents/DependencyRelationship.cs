using Backlog.Api.Core;
using System;

namespace Backlog.Api.DomainEvents
{
    public class CreateDependencyRelationship: BaseDomainEvent {
        public Guid DependencyRelationshipId { get; private set; } = Guid.NewGuid();
        public string Target { get; private set; }
        public string DependsOn { get; private set; }

        public CreateDependencyRelationship(string target, string dependsOn)
        {
            Target = target;
            DependsOn = dependsOn;
        }
    }

    public class UpdateDependencyRelationshipTargetId : BaseDomainEvent
    {
        public string Target { get; private set; }

        public UpdateDependencyRelationshipTargetId(string target)
        {
            Target = target;
        }
    }

    public class UpdateDependencyRelationshipDependsOnId : BaseDomainEvent
    {
        public string DependsOn { get; private set; }

        public UpdateDependencyRelationshipDependsOnId(string dependsOn)
        {
            DependsOn = dependsOn;
        }
    }

    public class RemoveDependencyRelationship: BaseDomainEvent
    {

    }
}
