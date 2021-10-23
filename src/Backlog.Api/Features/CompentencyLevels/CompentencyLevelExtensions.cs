using System;
using Backlog.Api.Models;

namespace Backlog.Api.Features
{
    public static class CompentencyLevelExtensions
    {
        public static CompentencyLevelDto ToDto(this CompentencyLevel compentencyLevel)
        {
            return new ()
            {
                CompentencyLevelId = compentencyLevel.CompentencyLevelId
            };
        }
        
    }
}
