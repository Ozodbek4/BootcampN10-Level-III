using Notification.Application.Common.Notifications.Models;

namespace Notification.Application.Common.Notifications.Services;

public interface ISmsRenderingService
{
    ValueTask<string> RenderAsync(SmsMessage smsMessage, CancellationToken cancellationToken = default);
}