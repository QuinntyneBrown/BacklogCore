using System;
using Backlog.Api.Models;

namespace Backlog.Api.Features
{
    public static class DifficultyExtensions
    {
        public static DifficultyDto ToDto(this Difficulty difficulty)
        {
            return new ()
            {
                DifficultyId = difficulty.DifficultyId
            };
        }
        
    }
}
