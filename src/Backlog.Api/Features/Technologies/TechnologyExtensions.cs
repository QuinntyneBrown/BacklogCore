using System;
using Backlog.Api.Models;

namespace Backlog.Api.Features
{
    public static class TechnologyExtensions
    {
        public static TechnologyDto ToDto(this Technology technology)
        {
            return new ()
            {
                TechnologyId = technology.TechnologyId
            };
        }
        
    }
}
