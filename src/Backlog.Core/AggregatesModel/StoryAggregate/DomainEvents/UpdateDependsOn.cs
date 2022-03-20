using Backlog.Api.Core;
using Backlog.Api.Models;
using System;
using System.Collections.Generic;

namespace Backlog.Api.DomainEvents
{

    public class UpdateDependsOn : BaseDomainEvent
    {
        public List<DependencyRelationship> DependsOn { get; private set; }

        public UpdateDependsOn(List<DependencyRelationship> dependsOn)
        {
            DependsOn = dependsOn;
        }
    }
}
