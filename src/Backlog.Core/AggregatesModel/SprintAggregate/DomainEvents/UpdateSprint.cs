using Backlog.SharedKernel;

namespace Backlog.Core;
public class UpdateSprint : BaseDomainEvent
{
    public string Name { get; private set; }
    public DateTime Start { get; private set; }
    public DateTime End { get; private set; }

    public UpdateSprint(string name, DateTime start, DateTime end)
    {
        Name = name;
        Start = start;
        End = end;
    }
}