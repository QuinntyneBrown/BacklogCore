using System;
using Backlog.Api.Models;

namespace Backlog.Api.Features
{
    public static class SprintExtensions
    {
        public static SprintDto ToDto(this Sprint sprint)
        {
            return new ()
            {
                SprintId = sprint.SprintId
            };
        }
        
    }
}
