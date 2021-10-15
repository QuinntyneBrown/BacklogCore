using System;
using Backlog.Api.Models;

namespace Backlog.Api.Features
{
    public static class StatusExtensions
    {
        public static StatusDto ToDto(this Status status)
        {
            return new ()
            {
                StatusId = status.StatusId
            };
        }
        
    }
}
