using Microsoft.EntityFrameworkCore;

namespace Backlog.Core
{
    [Owned]
    public class DependencyRelationship
    {
        public string DependsOn { get; private set; }

        private DependencyRelationship()
        {

        }

        public DependencyRelationship(string dependsOn)
        {
            DependsOn = dependsOn;
        }
    }
}
