using System;

namespace Backlog.Core;
public class Status
{
    public Guid StatusId { get; private set; }
    public string Name { get; private set; }
    public string Description { get; set; }

    private Status()
    {

    }

    public Status(string name, string description)
    {
        Name = name;
        Description = description;
    }
}