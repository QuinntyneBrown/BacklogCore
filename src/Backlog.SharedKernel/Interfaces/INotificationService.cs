using System;

namespace Backlog.SharedKernel;
public interface INotificationService
{
    void Subscribe(Action<dynamic> onNext);

    void OnNext(dynamic value);
}