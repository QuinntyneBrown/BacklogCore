using Microsoft.EntityFrameworkCore;

namespace Backlog.Api.Models
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