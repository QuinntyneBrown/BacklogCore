using System;
using Backlog.Core;

namespace Backlog.Core
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
