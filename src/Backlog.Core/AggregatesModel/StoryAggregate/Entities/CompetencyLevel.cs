using System;

namespace Backlog.Core
{
    public class CompetencyLevel
    {
        public Guid CompetencyLevelId { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        private CompetencyLevel()
        {

        }

        public CompetencyLevel(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
