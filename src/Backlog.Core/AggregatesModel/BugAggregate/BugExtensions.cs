using System;
using Backlog.Core;

namespace Backlog.Core
{
    public static class BugExtensions
    {
        public static BugDto ToDto(this Bug bug)
        {
            return new()
            {
                BugId = bug.BugId
            };
        }

    }
}
