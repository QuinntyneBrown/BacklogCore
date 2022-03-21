﻿namespace Backlog.SharedKernel
{
    public class BaseDomainEvent : IEvent
    {
        public DateTime Created => Convert.ToDateTime(Items[nameof(Created)]);
        public Guid CorrelationId => new Guid($"{Items[nameof(CorrelationId)]}");
        public Dictionary<string, object> Items { get; private set; } = new Dictionary<string, object>();

        public BaseDomainEvent()
        {
            Items.Add(nameof(Created), DateTime.Now);
            Items.Add(nameof(CorrelationId), Guid.NewGuid());
        }
    }
}
