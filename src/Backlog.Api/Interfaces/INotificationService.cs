using System;

namespace Backlog.Api.Interfaces
{
    public interface INotificationService
    {
        void Subscribe(Action<dynamic> onNext);

        void OnNext(dynamic value);
    }
}
