using System;
using Backlog.Api.Models;

namespace Backlog.Api.Features
{
    public static class DependencyRelationshipExtensions
    {
        public static DependencyRelationshipDto ToDto(this DependencyRelationship dependencyRelationship)
        {
            return new ()
            {
                DependencyRelationshipId = dependencyRelationship.DependencyRelationshipId
            };
        }
        
    }
}
