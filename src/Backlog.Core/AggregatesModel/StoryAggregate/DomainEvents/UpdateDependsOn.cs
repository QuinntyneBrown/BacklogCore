using Backlog.SharedKernel;

namespace Backlog.Core;

public class UpdateDependsOn : BaseDomainEvent
{
    public List<DependencyRelationship> DependsOn { get; private set; }

    public UpdateDependsOn(List<DependencyRelationship> dependsOn)
    {
        DependsOn = dependsOn;
    }
}
}
