using System;
using Backlog.Api.Models;

namespace Backlog.Api.Features
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
