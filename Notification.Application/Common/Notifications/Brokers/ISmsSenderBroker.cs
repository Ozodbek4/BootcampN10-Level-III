using Notification.Application.Common.Notifications.Models;

namespace Notification.Application.Common.Notifications.Brokers;

public interface ISmsSenderBroker
{
    ValueTask<bool> SendSmsAsync(SmsMessage smsMessage, CancellationToken cancellationToken = default);
}