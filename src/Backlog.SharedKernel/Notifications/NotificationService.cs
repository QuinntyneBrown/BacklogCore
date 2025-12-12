using Backlog.SharedKernel;
using System;
using System.Reactive.Subjects;

namespace Backlog.SharedKernel;
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
