using Backlog.Api.Interfaces;
using System;
using System.Reactive.Subjects;

namespace Backlog.Api.Core
{
    public class NotificationService : INotificationService
    {
        private readonly Subject<dynamic> _events = new Subject<dynamic>();

        public void Subscribe(Action<dynamic> onNext)
        {
            _events.Subscribe(onNext);
        }

        public void OnNext(dynamic value)
        {
            _events.OnNext(value);
        }
    }
}
