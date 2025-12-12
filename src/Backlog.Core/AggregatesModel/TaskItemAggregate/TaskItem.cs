
using Backlog.SharedKernel;
using System;

namespace Backlog.Core;
public class TaskItem : AggregateRoot
{
    public Guid TaskItemId { get; set; }

    public TaskItem(CreateTaskItem @event)
    {
        Apply(@event);
    }

    private TaskItem()
    {

    }

    protected override void EnsureValidState()
    {

    }

    protected override void When(dynamic @event)
    {

    }
}
}
