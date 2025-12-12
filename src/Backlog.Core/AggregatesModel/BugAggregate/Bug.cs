
using Backlog.SharedKernel;
using Backlog.SharedKernel;
using System;
using static System.String;

namespace Backlog.Core;

public class Bug : AggregateRoot
{
    public Guid BugId { get; private set; }
    public string Status { get; private set; } = Empty;

    public Bug(CreateBug @event)
    {
        Apply(@event);
    }

    private Bug()
    {

    }

    protected override void EnsureValidState()
    {

    }

    protected override void When(dynamic @event) => When(@event);

    private void When(CreateBug @event)
    {
        BugId = @event.BugId;
    }
}