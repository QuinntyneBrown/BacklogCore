using System;
using Backlog.Api.Models;

namespace Backlog.Api.Features
{
    public static class TaskItemExtensions
    {
        public static TaskItemDto ToDto(this TaskItem taskItem)
        {
            return new()
            {
                TaskItemId = taskItem.TaskItemId
            };
        }

    }
}
