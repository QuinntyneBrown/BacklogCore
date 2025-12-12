using System;
using Backlog.SharedKernel;

namespace Backlog.Core;
public static class StatusExtensions
{
    public static StatusDto ToDto(this Status status)
    {
        return new()
        {
            StatusId = status.StatusId,
            Name = status.Name,
            Description = status.Description
        };
    }

}