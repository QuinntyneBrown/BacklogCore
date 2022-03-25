

namespace Backlog.Core
{
    public class CreateSprint: BaseDomainEvent
    {
        public Guid SprintId { get; private set; } = Guid.NewGuid();
        public string Name { get; private set; }
        public DateTime Start { get; private set; }
        public DateTime End { get; private set; }

        public CreateSprint(string name, DateTime start, DateTime end)
        {
            Name = name;
            Start = start;
            End = end;  
        }        
    }
}
