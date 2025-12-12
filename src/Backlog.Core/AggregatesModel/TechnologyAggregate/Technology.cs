using System;

namespace Backlog.Core;
public class Technology
{
    public Guid TechnologyId { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }

    public Technology(string name, string description)
    {
        Name = name;
        Description = description;
    }

    private Technology()
    {

    }
}