using System;
using Backlog.Api.Models;

namespace Backlog.Api.Features
{
    public static class StoredEventExtensions
    {
        public static StoredEventDto ToDto(this StoredEvent storedEvent)
        {
            return new()
            {
                StoredEventId = storedEvent.StoredEventId
            };
        }

    }
}
